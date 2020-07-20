﻿using Calculator.IOperationServices;

namespace Calculator
{
    public class ApplicationStart
    {
        private IOperationResolverService _resolver;
        private IOperationPerformerService _operationPerformer;
        private IUIHandllerService _uIHandller;
        private string _option;
        private double[] _numbers;
        private double _result;
        private bool _next;

        public ApplicationStart(IOperationResolverService resolver,
                     IOperationPerformerService operationPerformer,
                     IUIHandllerService uIHandllerService)
        {
            _resolver = resolver;
            _operationPerformer = operationPerformer;
            _uIHandller = uIHandllerService;
        }

        public void Run()
        {
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
        }
    }
}
