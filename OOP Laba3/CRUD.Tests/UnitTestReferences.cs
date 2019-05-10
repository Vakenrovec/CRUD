using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Linq;

namespace CRUD.Tests
{
    [TestClass]
    public class UnitTestReferences
    {       
        public void CreateFlattop(ApplicationDataContext applicationDataContext, int speed, int releaseYear, string model,
            string identificator, string homePort, OceanType ocean, int amountRockets, int AmountSoldiers, int power, FuelType fuel)
        {
            BaseObject obj = new Flattop
            {
                Speed = speed,
                ReleaseYear = releaseYear,
                Model = model,
                Identificator = identificator,
                HomePort = homePort,
                Ocean = ocean,
                AmountRockets = amountRockets,
                AmountSoldiers = AmountSoldiers,
                WarPlanes = new List<WarPlane>(),
                engine = new Engine()
                {
                    Power = power,
                    Fuel = fuel,
                },
            };
            applicationDataContext.Objects.Add(obj);
        }              
        public void CreateWarPlane(ApplicationDataContext applicationDataContext, int speed, int releaseYear, string model,
            string identificator, int flighAltitude, int power, FuelType fuel)
        {
            BaseObject obj = new WarPlane
            {
                Speed = speed,
                ReleaseYear = releaseYear,
                Model = model,
                Identificator = identificator,
                FlightAltitude = flighAltitude,
                flattop = null,
                Pilot = null,
                engine = new Engine()
                {
                    Power = power,
                    Fuel = fuel,
                },
            };
            applicationDataContext.Objects.Add(obj);
        }               
        public void CreatePilot(ApplicationDataContext applicationDataContext, int height, int weight, string name,
            string sourname, int birthYear, int experience, SkillLevelType skillLevel)
        {
            BaseObject obj = new Pilot
            {
                Height = height,
                Weight = weight,
                BirthYear = birthYear,
                Name = name,
                Sourname = sourname,
                Experience = experience,
                SkillLevel = skillLevel,
            };
            applicationDataContext.Objects.Add(obj);
        }
        public void InitializeThreeObjectsAndReferences(ApplicationDataContext applicationDataContext)
        {
            CreateFlattop(applicationDataContext, 20, 2000, "flattop", "zx-89", "123w", OceanType.Pacific, 156, 800, 8000, FuelType.Petrol);
            CreateWarPlane(applicationDataContext, 380, 2010, "warplane", "aw-5.2", 6, 8500, FuelType.Petrol);
            CreatePilot(applicationDataContext, 190, 86, "Aleksey", "Meresiev", 1987, 12, SkillLevelType.Level_3);

            WarPlane warPlane = (WarPlane)applicationDataContext.Objects[1];
            warPlane.Pilot = (Pilot)applicationDataContext.Objects[2];
            Flattop flattop = (Flattop)applicationDataContext.Objects[0];
            warPlane.flattop = (Flattop)applicationDataContext.Objects[0];
            flattop.WarPlanes.Add(warPlane);
        }
        public void InitializeThreeObjectsWithoutReferences(ApplicationDataContext applicationDataContext)
        {
            CreateFlattop(applicationDataContext, 20, 2000, "flattop", "zx-89", "123w", OceanType.Pacific, 156, 800, 8000, FuelType.Petrol);
            CreateWarPlane(applicationDataContext, 300, 1985, "warplane", "aw-2", 5, 7000, FuelType.Parafin);
            CreatePilot(applicationDataContext, 190, 86, "Aleksey", "Meresiev", 1987, 12, SkillLevelType.Level_3);               
        }

        public void EqualFlattops(Flattop f1, Flattop f2)
        {
            Assert.AreEqual(f1.AmountRockets, f2.AmountRockets);
            Assert.AreEqual(f1.AmountSoldiers, f2.AmountSoldiers);
            Assert.AreEqual(f1.engine.Fuel, f2.engine.Fuel);
            Assert.AreEqual(f1.engine.Power, f2.engine.Power);
            Assert.AreEqual(f1.HomePort, f2.HomePort);
            Assert.AreEqual(f1.Identificator, f2.Identificator);
            Assert.AreEqual(f1.Model, f2.Model);
            Assert.AreEqual(f1.Ocean, f2.Ocean);
            Assert.AreEqual(f1.ReleaseYear, f2.ReleaseYear);
            Assert.AreEqual(f1.Speed, f2.Speed);
            //EqualWarPlanes(f1.WarPlanes[0], f2.WarPlanes[0]);            
        }
        public void EqualWarPlanes(WarPlane w1, WarPlane w2)
        {
            Assert.AreEqual(w1.engine.Fuel, w2.engine.Fuel);
            Assert.AreEqual(w1.engine.Power, w2.engine.Power);
            Assert.AreEqual(w1.FlightAltitude, w2.FlightAltitude);
            Assert.AreEqual(w1.Identificator, w2.Identificator);
            Assert.AreEqual(w1.ReleaseYear, w2.ReleaseYear);
            Assert.AreEqual(w1.Speed, w2.Speed);
            //EqualPilots(w1.Pilot, w2.Pilot);
            //EqualFlattops(w1.flattop, w2.flattop);
        }
        public void EqualPilots(Pilot p1, Pilot p2)
        {
            Assert.AreEqual(p1.BirthYear, p2.BirthYear);
            Assert.AreEqual(p1.Experience, p2.Experience);
            Assert.AreEqual(p1.Height, p2.Height);
            Assert.AreEqual(p1.Name, p2.Name);
            Assert.AreEqual(p1.SkillLevel, p2.SkillLevel);
            Assert.AreEqual(p1.Sourname, p2.Sourname);
            Assert.AreEqual(p1.Weight, p2.Weight);
        }
        public void EqualReferences(List<BaseObject> list)
        {
            Flattop flattop = (Flattop)list[0];
            WarPlane warPlane = (WarPlane)list[1];
            Pilot pilot = (Pilot)list[2];

            Assert.AreSame(flattop.WarPlanes[0], warPlane);
            Assert.AreSame(warPlane.Pilot, pilot);
        }
        public void EqualListsWithReferences(List<BaseObject> listFirst, List<BaseObject> listOther)
        {
            EqualFlattops((Flattop)listFirst[0], (Flattop)listOther[0]);
            EqualWarPlanes((WarPlane)listFirst[1], (WarPlane)listOther[1]);
            EqualPilots((Pilot)listFirst[2], (Pilot)listOther[2]);

            EqualReferences(listFirst);
            EqualReferences(listOther);
        }
        public void EqualNullReferences(List<BaseObject> list)
        {
            Flattop flattop = (Flattop)list[0];
            WarPlane warPlane = (WarPlane)list[1];
            Pilot pilot = (Pilot)list[2];

            Assert.AreEqual(flattop.WarPlanes.Count, 0);
            Assert.AreEqual(warPlane.flattop, null);
            Assert.AreEqual(warPlane.Pilot, null);
        }
        public void EqualListsWithoutReferences(List<BaseObject> listFirst, List<BaseObject> listOther)
        {
            EqualFlattops((Flattop)listFirst[0], (Flattop)listOther[0]);
            EqualWarPlanes((WarPlane)listFirst[1], (WarPlane)listOther[1]);
            EqualPilots((Pilot)listFirst[2], (Pilot)listOther[2]);

            EqualNullReferences(listFirst);
            EqualNullReferences(listOther);
        }

        public List<BaseObject> JsonSerialize(ApplicationDataContext applicationDataContext)
        {
            JsonFactory factory = new JsonFactory("Json");
            JsonSerializer serializer = (JsonSerializer)factory.CreateSerializer();
            string jsonSerealizedObjects = serializer.Serialize(applicationDataContext.Objects);
            return serializer.Deserialize(jsonSerealizedObjects);
        }
        public List<BaseObject> BinarySerialize(ApplicationDataContext applicationDataContext)
        {
            BinaryFactory factory = new BinaryFactory("Бинарная");
            BinarySerializer serializer = (BinarySerializer)factory.CreateSerializer();
            string BinarySerealizedObjects = serializer.Serialize(applicationDataContext.Objects);
            return serializer.Deserialize(BinarySerealizedObjects);
        }
        public List<BaseObject> ClientSerialize(ApplicationDataContext applicationDataContext)
        {
            ClientFactory factory = new ClientFactory("Клиентская");
            ClientSerializer serializer = (ClientSerializer)factory.CreateSerializer();
            string ClientSerealizedObjects = serializer.Serialize(applicationDataContext.Objects);
            return serializer.Deserialize(ClientSerealizedObjects);
        }

        public delegate List<BaseObject> SerializationDelegate(ApplicationDataContext applicationDataContext);
        public delegate void InitializeObjectsAndReferencesDelegate(ApplicationDataContext applicationDataContext);
        public delegate void EqualListsDelegate(List<BaseObject> listFirst, List<BaseObject> listOther);
        public void TestSerialization(SerializationDelegate serializer, InitializeObjectsAndReferencesDelegate initializeObjectsAndReferences,
            EqualListsDelegate equalLists)
        {
            ApplicationDataContext applicationDataContext = new ApplicationDataContext()
            {
                Objects = new List<BaseObject>(),
            };
            initializeObjectsAndReferences(applicationDataContext);
            List<BaseObject> listDesirializedObjects = serializer(applicationDataContext);
            equalLists(applicationDataContext.Objects, listDesirializedObjects);
        }

        [TestMethod]
        public void TestMethodJsonSerialization()
        {
            SerializationDelegate serializer = JsonSerialize;
            InitializeObjectsAndReferencesDelegate initializeObjectsAndReferences = InitializeThreeObjectsAndReferences;
            EqualListsDelegate equalLists = EqualListsWithReferences;
            TestSerialization(serializer, initializeObjectsAndReferences, equalLists);
        }
        [TestMethod]
        public void TestMethodJsonSerializationWithNullReferences()
        {
            SerializationDelegate serializer = JsonSerialize;
            InitializeObjectsAndReferencesDelegate initializeObjectsAndReferences = InitializeThreeObjectsWithoutReferences;
            EqualListsDelegate equalLists = EqualListsWithoutReferences;
            TestSerialization(serializer, initializeObjectsAndReferences, equalLists);
        }

        [TestMethod]
        public void TestMethodBinarySerialization()
        {
            SerializationDelegate serializer = BinarySerialize;
            InitializeObjectsAndReferencesDelegate initializeObjectsAndReferences = InitializeThreeObjectsAndReferences;
            EqualListsDelegate equalLists = EqualListsWithReferences;
            TestSerialization(serializer, initializeObjectsAndReferences, equalLists);
        }
        [TestMethod]
        public void TestMethodBinarySerializationWithNullReferences()
        {
            SerializationDelegate serializer = BinarySerialize;
            InitializeObjectsAndReferencesDelegate initializeObjectsAndReferences = InitializeThreeObjectsWithoutReferences;
            EqualListsDelegate equalLists = EqualListsWithoutReferences;
            TestSerialization(serializer, initializeObjectsAndReferences, equalLists);
        }

        [TestMethod]
        public void TestMethodClientSerialization()
        {
            SerializationDelegate serializer = ClientSerialize;
            InitializeObjectsAndReferencesDelegate initializeObjectsAndReferences = InitializeThreeObjectsAndReferences;
            EqualListsDelegate equalLists = EqualListsWithReferences;
            TestSerialization(serializer, initializeObjectsAndReferences, equalLists);
        }
        [TestMethod]
        public void TestMethodClientSerializationWithNullReferences()
        {
            SerializationDelegate serializer = ClientSerialize;
            InitializeObjectsAndReferencesDelegate initializeObjectsAndReferences = InitializeThreeObjectsWithoutReferences;
            EqualListsDelegate equalLists = EqualListsWithoutReferences;
            TestSerialization(serializer, initializeObjectsAndReferences, equalLists);
        }
    }
}
