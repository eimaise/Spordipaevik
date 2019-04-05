namespace WebApplication2.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
    }

    public class Exercise : BaseEntity
    {
        protected Exercise()
        {
            
        }
        public Exercise(int unitId)
        {
            UnitId = unitId;
        }
        public string Name { get; set; }
        public string Comment { get; set; }
        public virtual Unit Unit { get; set; }
        public int UnitId { get; set; }
    }

    public class Unit
    {
        protected Unit()
        {
        }

        public static Unit CreateTimeUnit(string name)
        {
            return new Unit
            {
                IsTime = true,
                Name = name
            };
        }

        public static Unit CreateValueUnit(string name)
        {
            return new Unit
            {
                IsTime = false,
                Name = name
            };
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public bool IsTime { get; private set; }
    }
}