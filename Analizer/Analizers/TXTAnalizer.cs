using System;
using System.IO;

namespace Analizer
{
    public class TXTAnalizer : AnalizerTemplate
    {
        private const string _format = ".txt";

        public TXTAnalizer(AnalizerData analizerData) : base(analizerData)
        {

        }

        public override void GetData()
        {
            try
            {
                string lPath = System.IO.Path.Combine(_analizerData.Settings.Directory, $"{_analizerData.Settings.SourceFileName}{_format}");
                using (StreamReader reader = new StreamReader(lPath))
                {
                    _analizerData.Data.Append(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                //Log here
                _analizerData.Success = false;
            }
        }
    }
}
