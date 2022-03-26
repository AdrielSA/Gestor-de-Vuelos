using System;

namespace Domain.CustomEntities
{
    public class LoginResult
    {
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
