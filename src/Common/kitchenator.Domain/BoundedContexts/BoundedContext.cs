namespace kitchenator.Domain.BoundedContexts
{
    public interface IBoundedContext
    {
        public interface Realestate : IBoundedContext { 
        }
        public interface Ordering : IBoundedContext { 
        }
        public interface Employment : IBoundedContext{
        }
    }
}
