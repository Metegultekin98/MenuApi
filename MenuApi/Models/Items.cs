namespace MenuApi.Models
{
    public class ItemsModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string SeName { get; set; }
        public int ProductId { get; set; }
        public string OldPrice { get; set; }
        public decimal OldPriceValue { get; set; }
        public string Price { get; set; }
        public string PriceWithDiscount { get; set; }
        public decimal PriceValue { get; set; }
        public decimal PriceWithDiscountValue { get; set; }
        public float SavingPercent { get; set; }
        public string SavingAmount { get; set; }
    }
}
