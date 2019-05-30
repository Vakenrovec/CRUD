namespace CodingPluginInterface
{
    public interface ICodingPlugin
    {
        string Code(byte[] array);
        byte[] Decode(string s);
        string Extension { get; }
    }
}
