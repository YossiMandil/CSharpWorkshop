namespace Processors
{
    public class DataProcessor<TInput, TOutput>
    {
        private readonly IProcessor<TInput, TOutput> _processor;

        public DataProcessor(IProcessor<TInput, TOutput> processor)
        {
            _processor = processor;
        }

        public IEnumerable<TOutput> ProccessData(IEnumerable<TInput> dataToProcess) => dataToProcess.Select(x => _processor.Process(x));
    }
}