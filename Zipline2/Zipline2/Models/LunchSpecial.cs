namespace Zipline2.Models
{
    public class LunchSpecial : OrderItem
    {
        public decimal PricePerPizzaTopping { get; set; }
        public decimal PriceAddToSalad { get; set; }
        public LunchSpecial(CustomerSelection guiData)
        { 
        }

        public override string ToString()
        {
            return "Lunch Special (slice and salad)";
        }
       
        public override void PopulateDisplayName()
        {
            //ItemName = DisplayNames.
        }

        public override void PopulatePricePerItem()
        {
            //BasePrice = Prices.
        }
    }
}
