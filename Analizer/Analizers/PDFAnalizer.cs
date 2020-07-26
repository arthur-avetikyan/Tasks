using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analizer
{
    public class PDFAnalizer : AnalizerTemplate
    {
        private const string _format = ".pdf";
        private IEnumerable<string> _longWords;

        public PDFAnalizer(AnalizerData analizerData) : base(analizerData)
        {

        }

        public override void GetData()
        {
            string lPath = System.IO.Path.Combine(_analizerData.Settings.Directory, $"{_analizerData.Settings.SourceFileName}{_format}");
            try
            {
                using (PdfDocument pdfDoc = new PdfDocument(new PdfReader(lPath)))
                {
                    for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                    {
                        PdfPage page = pdfDoc.GetPage(i);
                        _analizerData.Data.Append(PdfTextExtractor.GetTextFromPage(page));
                    }
                }
            }
            catch (Exception)
            {
                //Log here
                _analizerData.Success = false;
            }
        }

        public override void Analize()
        {
            base.Analize();
            _longWords = _analizerData.Words.Where(w => w.Length > 7).Distinct().OrderBy(o => o);
        }

        public override void ExportData()
        {
            _analizerData.Data.AppendLine($"Words that have more than 7 charachters.");
            foreach (string item in _longWords)
            {
                _analizerData.Data.AppendLine(item);
            }
            base.ExportData();
        }
    }
}
