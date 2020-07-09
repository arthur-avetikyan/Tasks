using System.Collections.Generic;

namespace OperationManager
{
    public class LibraryPaths
    {
        private const string _addition = "Add.dll";
        private const string _subtraction = "Subtraction.dll";
        private const string _multiplication = "Multiplication.dll";
        private const string _division = "Division.dll";
        private const string _operation = "IOperation.dll";

        public const string _pluginDirectory = @"C:\Users\arthu\source\repos\Tasks\Plugins";
        public Dictionary<int, string> availablePlugins = new Dictionary<int, string>
        {
            {1, _addition  },
            {2, _subtraction  },
            {3, _multiplication  },
            {4, _division  },
        };
    }
}
