using System.ComponentModel.DataAnnotations;

namespace UserService
{
    public class UserViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
    }
}
