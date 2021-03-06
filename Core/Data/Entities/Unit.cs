namespace Core.Data.Entities
{
    public class Unit : ValueObject<ResultValue>
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