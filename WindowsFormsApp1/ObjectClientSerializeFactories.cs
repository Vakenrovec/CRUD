using System;
using System.Collections.Generic;

namespace CRUD
{
    public interface IObjectClientSerializeFactory
    {
        bool CheckType(Type type);
        string SerializeObject(BaseObject baseObject, List<BaseObject> listObjects);
        void DeserializeObject(string serializedObject, BaseObject baseObject, List<BaseObject> listObjects);
    }

    public class FlattopClientSerializeFactory : IObjectClientSerializeFactory
    {
        public bool CheckType(Type type)
        { 
            if (type == typeof(Flattop))
            {
                return true;
            }
            return false;
        }

        private string SerializeFlattop(Flattop flattop, List<BaseObject> listObjects)
        {
            string serializedFlattop = flattop.GetType().ToString() + " ";

            serializedFlattop += flattop.AmountRockets.ToString() + " ";
            serializedFlattop += flattop.AmountSoldiers.ToString() + " ";
            serializedFlattop += flattop.HomePort + " ";
            serializedFlattop += flattop.Identificator + " ";
            serializedFlattop += flattop.Model + " ";
            serializedFlattop += flattop.Ocean.ToString() + " ";
            serializedFlattop += flattop.ReleaseYear.ToString() + " ";
            serializedFlattop += flattop.Speed.ToString() + " ";
            
            serializedFlattop += flattop.engine.Fuel.ToString() + " ";
            serializedFlattop += flattop.engine.Power.ToString() + " ";

            for (int i = 0; i < flattop.WarPlanes.Count; i++)
            {
                for (int j = 0; j < listObjects.Count; j++)
                {
                    if (flattop.WarPlanes[i] == listObjects[j])
                    {
                        serializedFlattop += j.ToString() + " ";
                        break;
                    }
                }
            }
            return serializedFlattop;
        }
        public string SerializeObject(BaseObject baseObject, List<BaseObject> listObjects)
        {
            return SerializeFlattop((Flattop)baseObject, listObjects);
        }

        private void DeserializeFlattop(string serializedFlattop, Flattop flattop, List<BaseObject> listObjects)
        {
            flattop.AmountRockets = int.Parse(serializedFlattop.Substring(0, serializedFlattop.IndexOf(" ")));
            serializedFlattop = serializedFlattop.Remove(0, serializedFlattop.IndexOf(" ") + 1);

            flattop.AmountSoldiers = int.Parse(serializedFlattop.Substring(0, serializedFlattop.IndexOf(" ")));
            serializedFlattop = serializedFlattop.Remove(0, serializedFlattop.IndexOf(" ") + 1);

            flattop.HomePort = serializedFlattop.Substring(0, serializedFlattop.IndexOf(" "));
            serializedFlattop = serializedFlattop.Remove(0, serializedFlattop.IndexOf(" ") + 1);

            flattop.Identificator = serializedFlattop.Substring(0, serializedFlattop.IndexOf(" "));
            serializedFlattop = serializedFlattop.Remove(0, serializedFlattop.IndexOf(" ") + 1);

            flattop.Model = serializedFlattop.Substring(0, serializedFlattop.IndexOf(" "));
            serializedFlattop = serializedFlattop.Remove(0, serializedFlattop.IndexOf(" ") + 1);

            flattop.Ocean = (OceanType)Enum.Parse(typeof(OceanType), serializedFlattop.Substring(0, serializedFlattop.IndexOf(" ")));
            serializedFlattop = serializedFlattop.Remove(0, serializedFlattop.IndexOf(" ") + 1);

            flattop.ReleaseYear = int.Parse(serializedFlattop.Substring(0, serializedFlattop.IndexOf(" ")));
            serializedFlattop = serializedFlattop.Remove(0, serializedFlattop.IndexOf(" ") + 1);

            flattop.Speed = int.Parse(serializedFlattop.Substring(0, serializedFlattop.IndexOf(" ")));
            serializedFlattop = serializedFlattop.Remove(0, serializedFlattop.IndexOf(" ") + 1);

            flattop.engine = new Engine();
            flattop.engine.Fuel = (FuelType)Enum.Parse(typeof(FuelType), serializedFlattop.Substring(0, serializedFlattop.IndexOf(" ")));
            serializedFlattop = serializedFlattop.Remove(0, serializedFlattop.IndexOf(" ") + 1);
            flattop.engine.Power = int.Parse(serializedFlattop.Substring(0, serializedFlattop.IndexOf(" ")));
            serializedFlattop = serializedFlattop.Remove(0, serializedFlattop.IndexOf(" ") + 1);

            flattop.WarPlanes = new List<WarPlane>();
            while (serializedFlattop != "") {
                flattop.WarPlanes.Add((WarPlane)listObjects[int.Parse(serializedFlattop.Substring(0, serializedFlattop.IndexOf(" ")))]);
                serializedFlattop = serializedFlattop.Remove(0, serializedFlattop.IndexOf(" ") + 1);
            }
        }
        public void DeserializeObject(string serializedObject, BaseObject baseObject, List<BaseObject> listObjects)
        {
            DeserializeFlattop(serializedObject, (Flattop)baseObject, listObjects);
        }
    }

    public class WarPlaneClientSerializeFactory : IObjectClientSerializeFactory
    {
        public bool CheckType(Type type)
        {
            return type == typeof(WarPlane);
        }

        private string SerializeWarPlane(WarPlane warPlane, List<BaseObject> listObjects)
        {
            // string builder
            string serializedWarPlane = warPlane.GetType().ToString() + " ";
            serializedWarPlane += warPlane.FlightAltitude.ToString() + " ";
            serializedWarPlane += warPlane.Identificator + " ";
            serializedWarPlane += warPlane.Model + " ";
            serializedWarPlane += warPlane.ReleaseYear.ToString() + " ";
            serializedWarPlane += warPlane.Speed.ToString() + " ";
            serializedWarPlane += warPlane.engine.Fuel.ToString() + " ";
            serializedWarPlane += warPlane.engine.Power.ToString() + " ";

            if (warPlane.flattop == null)
            {
                serializedWarPlane += "null ";
            }
            else
            {
                for (int i = 0; i < listObjects.Count; i++)
                {
                    if (warPlane.flattop == listObjects[i])
                    {
                        serializedWarPlane += i.ToString() + " ";
                        break;
                    }
                }
            }

            if (warPlane.Pilot == null)
            {
                serializedWarPlane += "null ";
            }
            else
            {
                for (int i = 0; i < listObjects.Count; i++)
                {
                    if (warPlane.Pilot == listObjects[i])
                    {
                        serializedWarPlane += i.ToString() + " ";
                        break;
                    }
                }
            }

            return serializedWarPlane;
        }
        public string SerializeObject(BaseObject baseObject, List<BaseObject> listObjects)
        {
            return SerializeWarPlane((WarPlane)baseObject, listObjects);
        }

        private void DeserializeWarPlane(string serializedWarPlane, WarPlane warPlane, List<BaseObject> listObjects)
        {
            warPlane.FlightAltitude = int.Parse(serializedWarPlane.Substring(0, serializedWarPlane.IndexOf(" ")));
            serializedWarPlane = serializedWarPlane.Remove(0, serializedWarPlane.IndexOf(" ") + 1);

            warPlane.Identificator = serializedWarPlane.Substring(0, serializedWarPlane.IndexOf(" "));
            serializedWarPlane = serializedWarPlane.Remove(0, serializedWarPlane.IndexOf(" ") + 1);

            warPlane.Model = serializedWarPlane.Substring(0, serializedWarPlane.IndexOf(" "));
            serializedWarPlane = serializedWarPlane.Remove(0, serializedWarPlane.IndexOf(" ") + 1);

            warPlane.ReleaseYear = int.Parse(serializedWarPlane.Substring(0, serializedWarPlane.IndexOf(" ")));
            serializedWarPlane = serializedWarPlane.Remove(0, serializedWarPlane.IndexOf(" ") + 1);

            warPlane.Speed = int.Parse(serializedWarPlane.Substring(0, serializedWarPlane.IndexOf(" ")));
            serializedWarPlane = serializedWarPlane.Remove(0, serializedWarPlane.IndexOf(" ") + 1);

            warPlane.engine = new Engine();
            warPlane.engine.Fuel = (FuelType)Enum.Parse(typeof(FuelType), serializedWarPlane.Substring(0, serializedWarPlane.IndexOf(" ")));
            serializedWarPlane = serializedWarPlane.Remove(0, serializedWarPlane.IndexOf(" ") + 1);
            warPlane.engine.Power = int.Parse(serializedWarPlane.Substring(0, serializedWarPlane.IndexOf(" ")));
            serializedWarPlane = serializedWarPlane.Remove(0, serializedWarPlane.IndexOf(" ") + 1);

            if (serializedWarPlane.Substring(0, serializedWarPlane.IndexOf(" ")) == "null")
            {
                warPlane.flattop = null;
            }
            else
            {
                warPlane.flattop = (Flattop)listObjects[int.Parse(serializedWarPlane.Substring(0, serializedWarPlane.IndexOf(" ")))];
            }
            serializedWarPlane = serializedWarPlane.Remove(0, serializedWarPlane.IndexOf(" ") + 1);

            if (serializedWarPlane.Substring(0, serializedWarPlane.IndexOf(" ")) == "null")
            {
                warPlane.Pilot = null;
            }
            else
            {
                warPlane.Pilot = (Pilot)listObjects[int.Parse(serializedWarPlane.Substring(0, serializedWarPlane.IndexOf(" ")))];
            }
            serializedWarPlane = serializedWarPlane.Remove(0, serializedWarPlane.IndexOf(" ") + 1);
        }
        public void DeserializeObject(string serializedObject, BaseObject baseObject, List<BaseObject> listObjects)
        {
            DeserializeWarPlane(serializedObject, (WarPlane)baseObject, listObjects);
        }
    }

    public class PilotClientSerializeFactory : IObjectClientSerializeFactory
    {
        public bool CheckType(Type type)
        {
            if (type == typeof(Pilot))
            {
                return true;
            }
            return false;
        }

        private string SerializePilot(Pilot pilot, List<BaseObject> listObjects)
        {
            string serializedPilot = pilot.GetType().ToString() + " ";
            serializedPilot += pilot.BirthYear.ToString() + " ";
            serializedPilot += pilot.Experience.ToString() + " ";
            serializedPilot += pilot.Height.ToString() + " ";
            serializedPilot += pilot.Name + " ";
            serializedPilot += pilot.SkillLevel.ToString() + " ";
            serializedPilot += pilot.Sourname + " ";
            serializedPilot += pilot.Weight.ToString() + " ";
            return serializedPilot;
        }
        public string SerializeObject(BaseObject baseObject, List<BaseObject> listObjects)
        {
            return SerializePilot((Pilot)baseObject, listObjects);
        }

        private void DeserializePilot(string serializedPilot, Pilot pilot, List<BaseObject> listObjects)
        {
            pilot.BirthYear = int.Parse(serializedPilot.Substring(0, serializedPilot.IndexOf(" ")));
            serializedPilot = serializedPilot.Remove(0, serializedPilot.IndexOf(" ") + 1);

            pilot.Experience = int.Parse(serializedPilot.Substring(0, serializedPilot.IndexOf(" ")));
            serializedPilot = serializedPilot.Remove(0, serializedPilot.IndexOf(" ") + 1);

            pilot.Height = int.Parse(serializedPilot.Substring(0, serializedPilot.IndexOf(" ")));
            serializedPilot = serializedPilot.Remove(0, serializedPilot.IndexOf(" ") + 1);

            pilot.Name = serializedPilot.Substring(0, serializedPilot.IndexOf(" "));
            serializedPilot = serializedPilot.Remove(0, serializedPilot.IndexOf(" ") + 1);

            pilot.SkillLevel = (SkillLevelType)Enum.Parse(typeof(SkillLevelType), serializedPilot.Substring(0, serializedPilot.IndexOf(" ")));
            serializedPilot = serializedPilot.Remove(0, serializedPilot.IndexOf(" ") + 1);

            pilot.Sourname = serializedPilot.Substring(0, serializedPilot.IndexOf(" "));
            serializedPilot = serializedPilot.Remove(0, serializedPilot.IndexOf(" ") + 1);

            pilot.Weight = int.Parse(serializedPilot.Substring(0, serializedPilot.IndexOf(" ")));
            serializedPilot = serializedPilot.Remove(0, serializedPilot.IndexOf(" ") + 1);
        }
        public void DeserializeObject(string serializedObject, BaseObject baseObject, List<BaseObject> listObjects)
        {
            DeserializePilot(serializedObject, (Pilot)baseObject, listObjects);
        }
    }
}