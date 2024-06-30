namespace Egyptian_association_of_cieliac_patients_api.DTO
{
    public class CartViewDto
    {
        public int Id { get; set; }
        public List<int> cartproductsId { get; set; } = new List<int>();
        public List<int> cartmaterialsId { get; set; } = new List<int>();
    }
}
