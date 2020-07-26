using System.Collections.Generic;
using System.Text;

namespace Analizer
{
    public class AnalizerData
    {
        public AnalizerData(IOSettings settings)
        {
            Settings = settings;
            Data = new StringBuilder();
        }

        public IOSettings Settings { get; set; }

        public StringBuilder Data { get; set; }

        public IEnumerable<string> Words { get; set; }

        public bool Success { get; set; }
    }
}
