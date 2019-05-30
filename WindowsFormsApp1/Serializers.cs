using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CRUD
{
    public interface ISerializer
    {
        string Serialize(List<BaseObject> listObjects);
        List<BaseObject> Deserialize(string serializedObjects);
    }

    public class JsonSerializer : ISerializer
    {
        public string Serialize(List<BaseObject> listObjects)
        {
            string serializedObjects = JsonConvert.SerializeObject(listObjects, Formatting.Indented,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.All,
                }
            );
            return serializedObjects;
        }
        public List<BaseObject> Deserialize(string serializedObjects)
        {
            List<BaseObject> listObjects = JsonConvert.DeserializeObject<List<BaseObject>>(serializedObjects,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    TypeNameHandling = TypeNameHandling.All,
                }
            );
            return listObjects;
        }
    }

    public class BinarySerializer : ISerializer
    {
        public string Serialize(List<BaseObject> listObjects)
        {
            FileStream fileStream = new FileStream("2.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, listObjects);
            fileStream.Close();

            byte[] ArrayObjects = File.ReadAllBytes("2.dat");
            string serializedObjects = Encoding.Unicode.GetString(ArrayObjects);                        
            
            return serializedObjects;
        }
        public List<BaseObject> Deserialize(string serializedObjects)
        {
            FileStream fileStream = new FileStream("2.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            List<BaseObject> listObjects = (List<BaseObject>)formatter.Deserialize(fileStream);
            fileStream.Close();
            return listObjects;
        }
    }

    public class ClientSerializer : ISerializer
    {
        public string Serialize(List<BaseObject> listObjects)
        {
            string serializedObjects = "";
            List<IObjectClientSerializeFactory> ObjectClientSerializeFactories = new List<IObjectClientSerializeFactory>()
            {
                new FlattopClientSerializeFactory(),
                new WarPlaneClientSerializeFactory(),
                new PilotClientSerializeFactory(),
            };
            for (int i = 0; i < listObjects.Count; i++)
            {
                for (int j = 0; j < ObjectClientSerializeFactories.Count; j++)
                {
                    if (ObjectClientSerializeFactories[j].CheckType(listObjects[i].GetType()))
                    {
                        serializedObjects += ObjectClientSerializeFactories[j].SerializeObject(listObjects[i], listObjects) + "\r\n";
                        break;
                    }
                }
            }
            return serializedObjects;
        }        
        public List<BaseObject> Deserialize(string serializedObjects)
        {
            List<BaseObject> listDeserializedObjects = new List<BaseObject>();
         
            string serializedObjectsCopy = string.Copy(serializedObjects);
            while (serializedObjectsCopy.IndexOf("\r\n") != -1)
            {
                string line = serializedObjectsCopy.Substring(0, serializedObjectsCopy.IndexOf("\r\n"));
                serializedObjectsCopy = serializedObjectsCopy.Remove(0, serializedObjectsCopy.IndexOf("\r\n") + 2);

                string objectType = line.Substring(0, line.IndexOf(" "));
                Type type = Type.GetType(objectType);
                BaseObject obj = (BaseObject)Activator.CreateInstance(type);
                listDeserializedObjects.Add(obj);
            }

            int i = 0;
            serializedObjectsCopy = string.Copy(serializedObjects);
            List<IObjectClientSerializeFactory> ObjectClientSerializeFactories = new List<IObjectClientSerializeFactory>()
            {
                new FlattopClientSerializeFactory(),
                new WarPlaneClientSerializeFactory(),
                new PilotClientSerializeFactory(),
            };
            while (serializedObjectsCopy.IndexOf("\r\n") != -1)
            {
                string line = serializedObjectsCopy.Substring(0, serializedObjectsCopy.IndexOf("\r\n"));
                line = line.Remove(0, line.IndexOf(" ") + 1);
                serializedObjectsCopy = serializedObjectsCopy.Remove(0, serializedObjectsCopy.IndexOf("\r\n") + 2);
                
                for (int j = 0; j < ObjectClientSerializeFactories.Count; j++)
                {
                    if (ObjectClientSerializeFactories[j].CheckType(listDeserializedObjects[i].GetType()))
                    {
                        ObjectClientSerializeFactories[j].DeserializeObject(line, listDeserializedObjects[i], listDeserializedObjects);
                        break;
                    }
                }
                i++;
            }

            return listDeserializedObjects;
        }
    }
}