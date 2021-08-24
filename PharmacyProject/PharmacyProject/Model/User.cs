
using System;
using System.Collections.Generic;

namespace Model
{
   public enum UserRole
    {
        DOCTOR,
        PHARMACIST,
        PATIENT
    }
    public class User
   {
       
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public String Role { get; set; }
        public Dictionary<String, int> ShoppingChart { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}