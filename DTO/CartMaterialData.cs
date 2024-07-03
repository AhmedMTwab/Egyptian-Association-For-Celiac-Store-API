namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class MaterialData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal total_price { get; set; }

        public string ImagePath { get; set; }
    }
}
