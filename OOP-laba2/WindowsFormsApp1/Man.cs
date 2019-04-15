namespace WindowsFormsApp1
{
    public enum SkillLevelType
    {
        Level_1,
        Level_2,
        Level_3,
        Level_Sniper,
    }
    public class Man : Object
    {
        [LabelAttribute("Рост(см)")]
        public int Height { get; set; }
        [LabelAttribute("Вес(кг)")]
        public int Weight { get; set; }
        [LabelAttribute("Год рождения")]
        public int BirthYear { get; set; }
        [LabelAttribute("Имя")]
        public string Name { get; set; }
        [LabelAttribute("Фамилия")]
        public string Sourname { get; set; }
        public override string ToString()
        {
            return Name + " " + Sourname;
        }        
    }
    [CommunicationTypeAttribute("Агрегация")]
    public class Pilot : Man
    {
        [LabelAttribute("Опыт(лет)")]
        public int Experience { get; set; }
        [LabelAttribute("Уровень навыков")]
        public SkillLevelType SkillLevel { get; set; }
        public override void ObjectDeleted(ApplicationDataContext applicationDataContext)
        {
            for (int i = 0; i < applicationDataContext.Objects.Count; i++)
            {
                Object obj = applicationDataContext.Objects[i];
                if (obj is WarPlane && ((WarPlane)obj).pilot == this)
                {    
                    ((WarPlane)obj).pilot = null;                   
                }
            }
        }
    }
}