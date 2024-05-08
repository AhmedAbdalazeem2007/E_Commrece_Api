
namespace Api_Core.Models.Order_Aggregate
{
    public class DelivaryMathod:BaseEntity
    {
        public DelivaryMathod()
        {
            
        }
        public DelivaryMathod(string shortName, string description, decimal cost, string delivaryTime)
        {
            ShortName = shortName;
            Description = description;
            Cost = cost;
            DelivaryTime = delivaryTime;
        }

        public string ShortName {  get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string DelivaryTime {  get; set; }

    }
}
