namespace Interface.Mapper
{
    public interface IMapper<Tin, TOut>
    {
        TOut Map(Tin @in);
    }
}
