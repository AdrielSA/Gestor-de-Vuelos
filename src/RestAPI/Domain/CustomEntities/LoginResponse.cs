using System;

namespace Domain.CustomEntities
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Rol { get; set; }
    }
}
