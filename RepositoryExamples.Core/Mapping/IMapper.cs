namespace Examples.Core.Mapping
{
    public interface IMapper<in TIn, out Tout>
    {
        Tout Map(TIn toMap);
    }
}