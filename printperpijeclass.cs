using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;

namespace Microsoft.Reporting.WinForms
{


    public static class printperpijeclass
    {
        public static void PrintToPrinter1(this LocalReport report)
        {
            PageSettings pageSettings = new PageSettings();

            //  pageSettings.PaperSize = report.GetDefaultPageSettings().PaperSize;
            pageSettings.Landscape = report.GetDefaultPageSettings().IsLandscape;
            pageSettings.Margins = report.GetDefaultPageSettings().Margins;

            Print(report, pageSettings);
        }

        public static void Print(this LocalReport report, PageSettings pageSettings)
        {
            string deviceInfo =
                $@"<DeviceInfo>
                    <OutputFormat>EMF</OutputFormat>
                    <PageWidth>{pageSettings.PaperSize.Width * 100}cm</PageWidth>
                    <PageHeight>{pageSettings.PaperSize.Height * 100}cm</PageHeight>
                    <MarginTop>{pageSettings.Margins.Top * 100}cm</MarginTop>
                    <MarginLeft>{pageSettings.Margins.Left * 100}cm</MarginLeft>
                    <MarginRight>{pageSettings.Margins.Right * 100}cm</MarginRight>
                    <MarginBottom>{pageSettings.Margins.Bottom * 100}cm</MarginBottom>
                </DeviceInfo>";
            Warning[] warnings;
            var streams = new List<Stream>();
            var pageIndex = 0;
            report.Render("Image", deviceInfo,
                (name, fileNameExtension, encoding, mimeType, willSeek) =>
                {
                    MemoryStream stream = new MemoryStream();
                    streams.Add(stream);
                    return stream;
                }, out warnings);
            foreach (Stream stream in streams)
                stream.Position = 0;
            if (streams == null || streams.Count == 0)
                throw new Exception("No stream to print.");
            using (PrintDocument printDocument = new PrintDocument())
            {
                printDocument.PrinterSettings.PrinterName = "OneNote for Windows 10";
                printDocument.DefaultPageSettings = pageSettings;
                if (!printDocument.PrinterSettings.IsValid)
                    throw new Exception("Can't find the default printer.");
                else
                {
                    printDocument.PrintPage += (sender, e) =>
                    {
                        Metafile pageImage = new Metafile(streams[pageIndex]);
                        Rectangle adjustedRect = new Rectangle(e.PageBounds.Left - (int)e.PageSettings.HardMarginX, e.PageBounds.Top - (int)e.PageSettings.HardMarginY, e.PageBounds.Width, e.PageBounds.Height);
                        e.Graphics.FillRectangle(Brushes.White, adjustedRect);
                        e.Graphics.DrawImage(pageImage, adjustedRect);
                        pageIndex++;
                        e.HasMorePages = (pageIndex < streams.Count);
                        e.Graphics.DrawRectangle(Pens.Transparent, adjustedRect);
                    };
                    printDocument.EndPrint += (Sender, e) =>
                    {
                        if (streams != null)
                        {
                            foreach (Stream stream in streams)
                                stream.Close();
                            streams = null;
                        }
                    };
                    printDocument.Print();
                }
            }
        }
    }
}