using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public enum FuelType
    {
        Petrol,
        Diesel,
        Parafin,
    }
    [CommunicationTypeAttribute("Композиция")]
    public class Engine : Object
    {
        [LabelAttribute("Тип топлива")]
        public FuelType Fuel { get; set; }
        [LabelAttribute("Мощность(л.с.)")]
        public int Power { get; set; }
    }
    public class Transport : Object
    {
        [LabelAttribute("Макс. скорость(км/ч)")]
        public int Speed { get; set; }       
        [LabelAttribute("Двигатель")]
        public Engine engine;
        [LabelAttribute("Год создания")]
        public int ReleaseYear { get; set; }
        [LabelAttribute("Модель")]
        public string Model { get; set; }
        [LabelAttribute("Идентификатор")]
        public string Identificator { get; set; }
        public override string ToString()
        {
            return Model + " " + Identificator;
        }
    }
    public enum OceanType
    {
        Pacific, 
        Indian, 
        Atlantic,
        Arctic,
    }
    public class Ship : Transport
    {
        [LabelAttribute("Океан")]
        public OceanType Ocean { get; set; }
        [LabelAttribute("Домашний порт")]
        public string HomePort { get; set; }
    }
    [CommunicationTypeAttribute("Агрегация")]
    public class Flattop : Ship
    {
        [LabelAttribute("Количество ракет")]
        public int AmountRockets { get; set; }
        [LabelAttribute("Количество солдат")]
        public int AmountSoldiers { get; set; }
        [LabelAttribute("Военные самолеты")]
        public List<WarPlane> WarPlanes = new List<WarPlane>();
        public override void ObjectDeleted(ApplicationDataContext applicationDataContext)
        {
            for (int i = 0; i < applicationDataContext.Objects.Count; i++)
            {
                Object obj = applicationDataContext.Objects[i];
                if (obj is WarPlane && ((WarPlane)obj).flattop == this)
                {
                    ((WarPlane)obj).flattop = null;
                }
            }
        }
    }
    [CommunicationTypeAttribute("Агрегация")]
    public class WarPlane : Transport
    {
        [LabelAttribute("Размах крыльев(м)")]
        public int FlightAltitude { get; set; }
        [LabelAttribute("Авианосец")]
        public Flattop flattop;
        [LabelAttribute("Пилот")]
        public Pilot pilot;
        public override void ObjectDeleted(ApplicationDataContext applicationDataContext)
        {
            for (int i = 0; i < applicationDataContext.Objects.Count; i++)
            {
                Object obj = applicationDataContext.Objects[i];
                if (obj is Flattop && ((Flattop)obj).WarPlanes != null && ((Flattop)obj).WarPlanes.Contains(this))
                {
                    ((Flattop)obj).WarPlanes.Remove(this);
                }
            }
        }
    }
}