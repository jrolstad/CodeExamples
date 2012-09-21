namespace Examples.Core.Visitors
{
    public interface IVisitor<in T>
    {
        void Visit(T item);
    }
}