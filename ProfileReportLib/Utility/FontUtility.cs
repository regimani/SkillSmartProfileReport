using PdfSharp.Drawing;

namespace SkillSmart.Reporting.ProfileReportLib.Utility
{
    public class FontUtility
    {
        public static XFont HeaderTitle = new XFont("Verdana", 9, XFontStyle.Bold);
        public static XFont HeaderContentBig = new XFont("Verdana", 8, XFontStyle.Regular);
        public static XFont HeaderContentNormal = new XFont("Verdana", 7, XFontStyle.Regular);
        public static XFont BodyContentNormal = new XFont("Verdana", 7, XFontStyle.Regular);
        public static XFont BodyContentTick = new XFont("WingDings", 7, XFontStyle.Regular);
    }
}
