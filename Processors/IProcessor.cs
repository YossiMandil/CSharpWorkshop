namespace Processors
{
    public interface IProcessor<TInput, Toutput>
    {
        Toutput Process(TInput input);
        string Name { get; }
    }
}
