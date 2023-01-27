namespace Shared.Infra
{
    public struct AsyncOutResult<T, OUT>
    {
        private readonly T returnValue;
        private readonly OUT result;

        public AsyncOutResult(T returnValue, OUT result)
        {
            this.returnValue = returnValue;
            this.result = result;
        }

        public T Result(out OUT result)
        {
            result = this.result;
            return returnValue;
        }
    }
}
