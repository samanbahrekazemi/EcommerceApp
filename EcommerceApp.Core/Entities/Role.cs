using EcommerceApp.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EcommerceApp.Domain.Entities
{
    public class Role : IdentityRole<string>, IEntity<string>
    {
    }
}
