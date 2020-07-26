using System;
using System.IO;
using System.Linq;

namespace Analizer
{
    public abstract class AnalizerTemplate
    {
        private int _wordsCount;
        private int _charsCount;

        protected AnalizerData _analizerData;

        public AnalizerTemplate(AnalizerData analizerData)
        {
            _analizerData = analizerData;
        }

        public void StartSequence()
        {
            GetData();
            ConvertToTextElements();
            Analize();
            ExportData();
            NotifyResultStatus();
        }

        public abstract void GetData();

        public void ConvertToTextElements()
        {
            _analizerData.Words = _analizerData.Data.ToString().Split(_analizerData.Settings.Seperators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            _analizerData.Data.Clear();
        }

        public virtual void Analize()
        {
            foreach (string item in _analizerData.Words)
            {
                _charsCount += item.Length;
            }
            _wordsCount = _analizerData.Words.Count();
        }

        public virtual void ExportData()
        {
            try
            {
                _analizerData.Data.AppendLine($"Text has {_wordsCount} words.");
                _analizerData.Data.AppendLine($"Text has {_charsCount} charachters.");
                File.AppendAllText(Path.Combine(_analizerData.Settings.Directory, _analizerData.Settings.DestinationFile), _analizerData.Data.ToString());
                _analizerData.Success = true;
            }
            catch (ArgumentException ex)
            {
                //Log here
                _analizerData.Success = false;
            }
            catch (IOException ex)
            {
                //Log here
                _analizerData.Success = false;
            }
        }

        public void NotifyResultStatus()
        {
            if (_analizerData.Success)
                Console.WriteLine("Success!");
            else
                Console.WriteLine("Failure!");
        }
    }
}
