namespace DiApi.Utility
{
    public class Operation: IOperationTransient, IOperationScoped, IOperationSingleTon
    {
        public Operation()
        {
            OperationId = Guid.NewGuid().ToString()[^4..];
            
        }
        public string OperationId {get;}
    }

}