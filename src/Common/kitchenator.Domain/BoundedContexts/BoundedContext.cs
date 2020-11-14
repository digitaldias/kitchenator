namespace kitchenator.Domain.BoundedContexts
{
    public interface IBoundedContext
    {
        public interface RealEstate : IBoundedContext { 
        }
        public interface Ordering : IBoundedContext { 
        }
        public interface Employment : IBoundedContext{
        }
    }
}
