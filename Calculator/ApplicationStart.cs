using Calculator.IOperationServices;

namespace Calculator
{
    public class ApplicationStart
    {
        private ILoggerService _loggerService;
        private IOperationResolverService _resolver;
        private IOperationPerformerService _operationPerformer;
        private IUIHandllerService _uIHandller;
        private string _option;
        private double[] _numbers;
        private double _result;
        private bool _next;

        public ApplicationStart(IOperationResolverService resolver,
                     IOperationPerformerService operationPerformer,
                     IUIHandllerService uIHandllerService,
                     ILoggerService loggerService)
        {
            _loggerService = loggerService;
            _resolver = resolver;
            _operationPerformer = operationPerformer;
            _uIHandller = uIHandllerService;
        }

        public void Run()
        {
            _loggerService.RecordLog(LogTypes.Event, "Application started.");
            do
            {
                _option = _uIHandller.GetOperationInput(_resolver.Operations);
                _operationPerformer.SetOperation(_resolver.ResolveOperation(_option));
                _numbers = _uIHandller.GetNumbersInput();
                _result = _operationPerformer.PerformOperation(_numbers);
                _uIHandller.DisplayOutput(_option, _result, _numbers);

                _next = _uIHandller.GetExitOption();
            }
            while (_next);
            _loggerService.RecordLog(LogTypes.Event, "Application ended.");
        }
    }
}
