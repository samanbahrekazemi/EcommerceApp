using EcommerceApp.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EcommerceApp.Domain.Entities
{
    public class User : IdentityUser<string> , IEntity<string>
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}