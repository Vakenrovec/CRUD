using System.Collections.Generic;

namespace CRUD
{
    public interface IFactory
    {
        BaseObject CreateObject();
    }
    public class FlattopFactory : IFactory
    {
        public FlattopFactory(string name)
        {
            Name = name;
        }
        public BaseObject CreateObject()
        {
            Flattop flattop = new Flattop
            {
                engine = new Engine(),
                WarPlanes = new List<WarPlane>()
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
        public BaseObject CreateObject()
        {
            WarPlane warPlane = new WarPlane
            {
                engine = new Engine()
            };
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
        public BaseObject CreateObject()
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