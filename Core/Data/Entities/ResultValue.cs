namespace Core.Data.Entities
{
    public class ResultValue : ValueObject<ResultValue>
    {
        public string UnitName { get; set; }
        public decimal Value { get; set; }

        public ResultValue(string unitName, decimal value)
        {
            UnitName = unitName;
            Value = value;
        }
    }
}