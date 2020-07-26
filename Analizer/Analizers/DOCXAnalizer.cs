using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analizer
{
    public class DOCXAnalizer : AnalizerTemplate
    {
        private const string _format = ".docx";
        private IEnumerable<string> _shortWords;

        public DOCXAnalizer(AnalizerData analizerData) : base(analizerData)
        {

        }

        public override void GetData()
        {
            try
            {
                string lPath = System.IO.Path.Combine(_analizerData.Settings.Directory, $"{_analizerData.Settings.SourceFileName}{_format}");
                using (WordprocessingDocument lDoc = WordprocessingDocument.Open(lPath, false))
                {
                    foreach (var item in lDoc.MainDocumentPart.Document.Elements())
                    {
                        _analizerData.Data.Append(item.InnerText);
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
            _shortWords = _analizerData.Words.Where(w => w.Length < 3).Distinct().OrderBy(o => o);
        }

        public override void ExportData()
        {
            _analizerData.Data.AppendLine($"Words that have less than 3 charachters.");
            foreach (string item in _shortWords)
            {
                _analizerData.Data.AppendLine(item);
            }
            base.ExportData();
        }
    }
}
