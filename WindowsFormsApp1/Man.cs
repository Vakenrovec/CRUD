using System;

namespace CRUD
{
    public enum SkillLevelType
    {
        Level_1,
        Level_2,
        Level_3,
        Level_Sniper,
    }

    [Serializable]
    public class Man : BaseObject
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
    [Serializable]
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
                BaseObject obj = applicationDataContext.Objects[i];
                if (obj is WarPlane && ((WarPlane)obj).Pilot == this)
                {    
                    ((WarPlane)obj).Pilot = null;                   
                }
            }
        }
    }
}