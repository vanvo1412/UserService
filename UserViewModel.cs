using System.ComponentModel.DataAnnotations;

namespace UserService
{
    public class UserViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
    }
}
