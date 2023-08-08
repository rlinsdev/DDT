namespace DiApi.Utility
{
    public interface IOperation
    {
        string OperationId { get; }
    }

    public interface IOperationTransient : IOperation {}
    public interface IOperationScoped : IOperation {}
    public interface IOperationSingleTon : IOperation {}
}