using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.IOperationServices
{
    public interface ICalculationService
    {
        double Calculate(List<string> options, List<double> numbers);
    }
}
