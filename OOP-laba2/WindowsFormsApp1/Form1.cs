using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {       
        public FormMain()
        {
            InitializeComponent();
        }
        public ApplicationDataContext applicationDataContext;
        public void CreateFlattop(int speed, int releaseYear, string model, string identificator, string homePort, 
            OceanType ocean, int amountRockets, int AmountSoldiers, int power, FuelType fuel)
        {
            Object obj = new Flattop
            {
                Speed = speed,
                ReleaseYear =releaseYear,
                Model = model,
                Identificator = identificator,
                HomePort = homePort,
                Ocean = ocean,
                AmountRockets =amountRockets,
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
        public void CreateWarPlane(int speed, int releaseYear, string model, string identificator, int flighAltitude, 
            int power, FuelType fuel)
        {
            Object obj = new WarPlane
            {
                Speed = speed,
                ReleaseYear = releaseYear,
                Model = model,
                Identificator = identificator,
                FlightAltitude = flighAltitude,
                flattop = null,
                pilot = null,
                engine = new Engine()
                {
                    Power = power,
                    Fuel = fuel,
                },
            };
            applicationDataContext.CallObjectCreatedEvent(applicationDataContext.Objects, obj);
        }
        public void CreatePilot(int height, int weight, string name, string sourname, int birthYear, int experience,
            SkillLevelType skillLevel)
        {
            Object obj = new Pilot
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
            CreateFlattop(20, 2000, "flattop", "zx-89", "123w", OceanType.Pacific, 156 , 800, 8000, FuelType.Petrol);
            CreateFlattop(15, 2010, "flattop", "cv-1", "ww.2", OceanType.Indian, 500, 1500, 12000, FuelType.Diesel);
            CreateFlattop(30, 1980, "flattop", "cv-2", "w1", OceanType.Atlantic, 205, 700, 7000, FuelType.Parafin);

            CreateWarPlane(300, 1985, "warplane", "aw-2", 5, 7000, FuelType.Parafin);
            CreateWarPlane(380, 2010, "warplane", "aw-5.2", 6, 8500, FuelType.Petrol);
            CreateWarPlane(200, 2015, "warplane", "qw-5.5", 3, 4500, FuelType.Parafin);
            CreateWarPlane(480, 2005, "warplane", "zw-10.2", 6, 9500, FuelType.Petrol);
            CreateWarPlane(580, 2000, "warplane", "p-5", 6, 8500, FuelType.Diesel);

            CreatePilot(190, 86, "Aleksey", "Meresiev", 1987, 12, SkillLevelType.Level_3);
            CreatePilot(195, 82, "Boris", "Abramov", 1981, 17, SkillLevelType.Level_Sniper);
            CreatePilot(199, 88, "Sergey", "Agapov", 1980, 18, SkillLevelType.Level_Sniper);
            CreatePilot(185, 85, "Yourii", "Antipov", 1985, 15, SkillLevelType.Level_3);
            CreatePilot(180, 71, "Sergey", "Anohin", 1990, 5, SkillLevelType.Level_1);
            CreatePilot(189, 80, "Semen", "Antopov", 1979, 20, SkillLevelType.Level_2);
            CreatePilot(193, 89, "Valentin", "Baranov", 1977, 19, SkillLevelType.Level_Sniper);            
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            applicationDataContext = new ApplicationDataContext()
            {   
                Objects = new List<Object>(),
                ComboBoxObjects = ComboBoxObjects,
            };

            applicationDataContext.ObjectCreatedEvent += applicationDataContext.AddObjectToList;
            applicationDataContext.ObjectCreatedEvent += applicationDataContext.AddObjectToComboBox;

            applicationDataContext.ObjectDeletedEvent += applicationDataContext.DeleteObjectFromList;
            applicationDataContext.ObjectDeletedEvent += applicationDataContext.DeleteObjectFromComboBox;

            IFactory[] Arr = new IFactory[] {
                new FlattopFactory("Авианосец"),
                new WarPlaneFactory("Военный самолет"),
                new PilotFactory("Пилот"),
            };
            ComboBoxCreate.Items.AddRange(Arr);

            CreateSomeObjects(applicationDataContext);
        }
        private void ComboBoxCreate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IFactory factory = (IFactory)ComboBoxCreate.SelectedItem;
            Object obj = factory.CreateObject();

            obj.Update(applicationDataContext, true);
        }
        private void ButtonDeleteObject_Click(object sender, EventArgs e)
        {
            Object selectedItem = (Object)this.ComboBoxObjects.SelectedItem;
            selectedItem.ObjectDeleted(applicationDataContext);
            applicationDataContext.CallObjectDeletedEvent(applicationDataContext.Objects, selectedItem);
        }
        private void ButtonUpdateObject_Click(object sender, EventArgs e)
        {
            Object selectedItem = (Object)this.ComboBoxObjects.SelectedItem;
            selectedItem.Update(applicationDataContext, false);
        }
    }
}
