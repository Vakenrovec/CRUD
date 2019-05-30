namespace CRUD
{
    public abstract class SerializerFactory
    {
        public abstract  ISerializer CreateSerializer();
        public abstract string Extension { get;}
    }
    public class JsonFactory : SerializerFactory
    {
        public JsonFactory(string name)
        {
            Name = name;
        }
        public override ISerializer CreateSerializer()
        {
            return new JsonSerializer();
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public override string Extension { get; } = ".json";
    }
    public class BinaryFactory : SerializerFactory
    {
        public BinaryFactory(string name)
        {
            Name = name;
        }
        public override ISerializer CreateSerializer()
        {
            return new BinarySerializer();
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public override string Extension { get; } = ".bin";
    }
    public class ClientFactory : SerializerFactory
    {
        public ClientFactory(string name)
        {
            Name = name;
        }
        public override ISerializer CreateSerializer()
        {
            return new ClientSerializer();
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public override string Extension { get; } = ".client";
    }
}