namespace Examples.Core.Mapping
{
    public interface IMapper<in TIn, out Tout>
    {
        Tout Map(TIn toMap);
    }

    public interface IGenericMapper<in TIn>
    {
        Tout Map<Tout>(TIn toMap);
    }
}