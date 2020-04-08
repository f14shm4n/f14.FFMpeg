namespace FFMpeg.Arguments
{
    public interface IArgumentBuilder
    {
        IArgumentBuilder Add(IArgument argument);
        T? Get<T>() where T : class, IArgument;
        string Build();
    }
}
