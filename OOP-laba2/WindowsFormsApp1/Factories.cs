namespace WindowsFormsApp1
{
    public interface IFactory
    {
        Object CreateObject();
    }
    public class FlattopFactory : IFactory
    {
        public FlattopFactory(string name)
        {
            Name = name;
        }
        public Object CreateObject()
        {
            Flattop flattop = new Flattop
            {
                engine = new Engine()
            };
            return flattop;
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    public class WarPlaneFactory : IFactory
    {
        public WarPlaneFactory(string name)
        {
            Name = name;
        }
        public Object CreateObject()
        {
            WarPlane warPlane = new WarPlane();
            warPlane.engine = new Engine();
            return warPlane;
        }
        public string Name{ get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
    public class PilotFactory : IFactory
    {
        public PilotFactory(string name)
        {
            Name = name;
        }
        public Object CreateObject()
        {
            return new Pilot();
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}