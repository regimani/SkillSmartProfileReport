using PdfSharp.Drawing;
using PdfSharp.Pdf;
using SkillSmart.Reporting.ProfileReportLib.Utility;
using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using SkillSmart.Reporting.ProfileReportLib.Model;
namespace SkillSmart.Reporting.ProfileReportLib
{
    public class ProfileReport
    {
        public byte[] Generate()
        {
            PdfDocument document = new PdfDocument();
            PrepareDocument(document);

            string filename = "C:/Temp/SkillSmartReporting/" + Guid.NewGuid() + ".pdf";
            document.Save(filename);
            Process.Start(filename);

            return File.ReadAllBytes(filename); 
        }

        private void PrepareDocument(PdfDocument document)
        {
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            DrawHeader(gfx);
            DrawPrerequisites(gfx);
            DrawBody(gfx);
            DrawFooter(gfx);

            // Second Page
            page = document.AddPage();
            gfx = XGraphics.FromPdfPage(page);

            DrawHeader(gfx);
            DrawPrerequisites(gfx);
            DrawBody(gfx);
            DrawFooter(gfx);

        }

        private void DrawHeader(XGraphics gfx)
        {
            gfx.DrawLine(XPens.Orange, 50, 50, 250, 50);

            XRect rcImage = new XRect(50, 35, 100, 15);
            gfx.DrawRectangle(XBrushes.Orange, rcImage);
            gfx.DrawString("APPLICANT", FontUtility.HeaderTitle, XBrushes.White, rcImage, XStringFormats.Center);

            gfx.DrawString("John Doe", FontUtility.HeaderContentBig, XBrushes.Black, new XRect(50, 62, 100, 0));
            gfx.DrawString("test@skillsmart.usa", FontUtility.HeaderContentNormal, XBrushes.Black, new XRect(50, 75, 100, 0));
            gfx.DrawString("802-123-4567", FontUtility.HeaderContentNormal, XBrushes.Black, new XRect(50, 85, 100, 0));

            gfx.DrawLine(XPens.DarkBlue, 280, 50, 500, 50);

            XRect rcImage2 = new XRect(280, 35, 100, 15);
            gfx.DrawRectangle(XBrushes.DarkBlue, rcImage2);
            gfx.DrawString("APPLYING FOR", FontUtility.HeaderTitle, XBrushes.White, rcImage2, XStringFormats.Center);

            gfx.DrawString("Cyber Reverse Engineer", FontUtility.HeaderContentBig, XBrushes.Black, new XRect(280, 62, 100, 0));
            gfx.DrawString("iNovex Information Systems Savage, MD", FontUtility.HeaderContentNormal, XBrushes.Black, new XRect(280, 75, 100, 0));

            XPen pen = new XPen(XColors.Orange, 1);
            pen.DashStyle = XDashStyle.Solid;
            gfx.DrawPie(pen, XBrushes.OrangeRed, 545, 5, 60, 60, 90, 90);
            gfx.DrawString("18", FontUtility.HeaderTitle, XBrushes.White, new XRect(555, 50, 50, 0));
        }

        private void DrawPrerequisites(XGraphics gfx)
        {
            XRect rcImage = new XRect(50, 120, 150, 50);
            gfx.DrawRectangle(new XPen(XColors.LightGray, 1), XBrushes.White, rcImage);
            gfx.DrawString("Prerequisites", FontUtility.HeaderContentBig, XBrushes.Black, new XRect(52, 130, 150, 0));
            gfx.DrawLine(XPens.Black, 52, 132, 110, 132);

            List<Requisite> refList = TestDataLibrary.RequisitesGet();

            for(int x=0; x< refList.Count; x++)
            {
                gfx.DrawString(refList[x].Icon, FontUtility.BodyContentTick, XBrushes.Green, new XRect(52, 140 + ( x * 10), 10, 0));
                gfx.DrawString(refList[x].Name, FontUtility.BodyContentNormal, XBrushes.Black, new XRect(62, 140 + (x * 10), 150, 0));
            }

            gfx.DrawLine(XPens.Black, 55, 171, 200, 171);
            gfx.DrawLine(XPens.Black, 201, 125, 201, 171);
        }

        private void DrawBody(XGraphics gfx)
        {
            for (int x = 0; x < 15; x++)
            {
                XGraphicsState state1 = gfx.Save();
                gfx.RotateAtTransform(-70, new XPoint(200+(x*20), 250));
                gfx.DrawString("Long Text Here : Always expect more "+(x+1), FontUtility.HeaderContentNormal, XBrushes.Black, new XPoint(200+(x * 20), 250));
                gfx.Restore(state1);
            }

            for (int x = 0; x < 15; x++)
            {
                XPen pen = new XPen(XColors.Gray, 1);
                gfx.DrawRectangle(pen, XBrushes.White, new XRect(195+(x*20), 260, 8, 25));
                if(x%2 == 0)
                gfx.DrawRectangle(XBrushes.LightGray, new XRect(195 + (x * 20), 270, 8, 15));
            }

            int lineHeight = 20;
            int topHeight = 0;
            for (int x = 0; x < 20; x++)
            {
                topHeight = 300 + lineHeight * x; 
                gfx.DrawLine(XPens.LightGray, 50, topHeight, 490, topHeight);

                if(x%2 == 0)
                    gfx.DrawString("&", FontUtility.BodyContentTick, XBrushes.Green, new XRect(50, topHeight + 8, 10, 0));
                else
                    gfx.DrawString("#", FontUtility.BodyContentTick, XBrushes.Green, new XRect(50, topHeight + 8, 10, 0));
                gfx.DrawString("Associate Consultant "+(x+1), FontUtility.BodyContentNormal, XBrushes.Black, new XRect(60, topHeight+8, 100, 0));
                gfx.DrawString("8/2011 - present", FontUtility.BodyContentNormal, XBrushes.Black, new XRect(50, topHeight + 16, 100, 0));
                for (int y = 0; y < 16; y++)
                {
                    XPen pen = new XPen(XColors.Gray, 1);
                    gfx.DrawLine(pen, new XPoint(190+(y*20), topHeight), new XPoint(190+(y*20), (topHeight + 20)));
                    if (y % 2 == 0)
                    gfx.DrawImage(XImage.FromFile("../Images/Green-Tick.png"), new XRect(190 + (y * 20) + 5, topHeight + 6, 10, 10));
                }
            }
            gfx.DrawLine(XPens.LightGray, 50, topHeight+ lineHeight, 490, topHeight+ lineHeight);
        }

        private void DrawFooter(XGraphics gfx)
        {
            gfx.DrawString("References", FontUtility.HeaderContentBig, XBrushes.Black, new XRect(50, 723, 100, 0));
            gfx.DrawLine(XPens.Gray, 50, 725, 550, 725);

            List<JobReference> refList = TestDataLibrary.ReferencesGet();
            for(int x=0; x<refList.Count; x++)
            {
                gfx.DrawString("R"+(x+1)+":", FontUtility.HeaderContentNormal, XBrushes.Black, new XRect(50 +(x*100), 735, 10, 0));
                gfx.DrawString(refList[x].Name, FontUtility.HeaderContentNormal, XBrushes.Black, new XRect(65 + (x * 100), 735, 50, 0));
                gfx.DrawString(refList[x].Designation, FontUtility.HeaderContentNormal, XBrushes.Black, new XRect(65 + (x * 100), 745, 50, 0));
                gfx.DrawString(refList[x].Phone, FontUtility.HeaderContentNormal, XBrushes.Black, new XRect(65 + (x * 100), 755, 50, 0));
                gfx.DrawString(refList[x].Email, FontUtility.HeaderContentNormal, XBrushes.Black, new XRect(65 + (x * 100), 765, 50, 0));
            }
        }
    }
}
