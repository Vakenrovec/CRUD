using CRUD;
using System.Collections.Generic;

public class CreateObject
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
        applicationDataContext.CallObjectCreatedEvent(applicationDataContext.Objects, obj);
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
        applicationDataContext.CallObjectCreatedEvent(applicationDataContext.Objects, obj);
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
        applicationDataContext.CallObjectCreatedEvent(applicationDataContext.Objects, obj);
    }
    public void CreateSomeObjects(ApplicationDataContext applicationDataContext)
    {
        CreateFlattop(applicationDataContext, 20, 2000, "flattop", "zx-89", "123w", OceanType.Pacific, 156, 800, 8000, FuelType.Petrol);
        //CreateFlattop(applicationDataContext, 15, 2010, "flattop", "cv-1", "ww.2", OceanType.Indian, 500, 1500, 12000, FuelType.Diesel);

        CreateWarPlane(applicationDataContext, 300, 1985, "warplane", "aw-2", 5, 7000, FuelType.Parafin);        
        CreateWarPlane(applicationDataContext, 380, 2010, "warplane", "aw-5.2", 6, 8500, FuelType.Petrol);
        //CreateWarPlane(applicationDataContext, 200, 2015, "warplane", "qw-5.5", 3, 4500, FuelType.Parafin);

        CreatePilot(applicationDataContext, 190, 86, "Aleksey", "Meresiev", 1987, 12, SkillLevelType.Level_3);
        CreatePilot(applicationDataContext, 195, 82, "Boris", "Abramov", 1981, 17, SkillLevelType.Level_Sniper);
        CreatePilot(applicationDataContext, 199, 88, "Sergey", "Agapov", 1980, 18, SkillLevelType.Level_Sniper);
        //CreatePilot(applicationDataContext, 185, 85, "Yourii", "Antipov", 1985, 15, SkillLevelType.Level_3);
        //CreatePilot(applicationDataContext, 180, 71, "Sergey", "Anohin", 1990, 5, SkillLevelType.Level_1);
        //CreatePilot(applicationDataContext, 189, 80, "Semen", "Antopov", 1979, 20, SkillLevelType.Level_2);
        //CreatePilot(applicationDataContext, 192, 89, "Valentin", "Baranov", 1977, 19, SkillLevelType.Level_Sniper);   

        //Flattop fl = applicationDataContext.Objects[0] as Flattop;
        //fl.WarPlanes.Add(applicationDataContext.Objects[2] as WarPlane);
        //fl.WarPlanes.Add(applicationDataContext.Objects[3] as WarPlane);
        //WarPlane wp = applicationDataContext.Objects[2] as WarPlane;
        //wp.flattop = fl;
        //wp = applicationDataContext.Objects[3] as WarPlane;
        //wp.flattop = fl;

        //fl = applicationDataContext.Objects[1] as Flattop;
        //fl.WarPlanes.Add(applicationDataContext.Objects[4] as WarPlane);
        //wp = applicationDataContext.Objects[4] as WarPlane;
        //wp.flattop = fl;

        //Pilot p = applicationDataContext.Objects[5] as Pilot;
        //wp = applicationDataContext.Objects[2] as WarPlane;
        //wp.Pilot = p;

        //p = applicationDataContext.Objects[6] as Pilot;
        //wp = applicationDataContext.Objects[3] as WarPlane;
        //wp.Pilot = p;



        //WarPlane warPlane = (WarPlane)applicationDataContext.Objects[1];
        //warPlane.Pilot = (Pilot)applicationDataContext.Objects[2];
        //Flattop flattop = (Flattop)applicationDataContext.Objects[0];
        //warPlane.flattop = (Flattop)applicationDataContext.Objects[0];
        //flattop.WarPlanes.Add(warPlane);
    }
}