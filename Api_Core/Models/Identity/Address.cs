

namespace Api_Core.Models.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        [ForeignKey("user")]
        public string AppUserId {  get; set; }
        public ApplicationUser user { get; set; }
    }
}
