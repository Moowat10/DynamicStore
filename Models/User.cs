using System.ComponentModel.DataAnnotations;

namespace DynamicStore.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Obsolete]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Obsolete]
        [Required]
        public string Email { get; set; }

        public ICollection<UserStorePermission>? Permissions { get; set; }

        public ICollection<Store>? Stores { get; set; }

    }
}