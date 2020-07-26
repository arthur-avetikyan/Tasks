namespace Analizer
{
    public class Application
    {
        private IAnalizerFactory _analizerFactory;

        public Application(IAnalizerFactory analizerFactory)
        {
            _analizerFactory = analizerFactory;
        }

        public void Run()
        {
            foreach (AnalizerTemplate analizer in _analizerFactory.GetAnalizers())
            {
                analizer.StartSequence();
            }
        }
    }
}
