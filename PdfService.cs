using NReco.PdfGenerator;
using System;


namespace EmployeeRegistration.Models
{
    public class PdfService
    {
        public byte[] GeneratePdf(string htmlContent)
        {
            var converter = new HtmlToPdfConverter();

            // Optional settings
            converter.Orientation = PageOrientation.Portrait;
            converter.Size = PageSize.A4;
            converter.CustomWkHtmlArgs = "--minimum-font-size 12";

            return converter.GeneratePdf(htmlContent);
        }
    }
}
