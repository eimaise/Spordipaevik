namespace Core.Data.Entities
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
}