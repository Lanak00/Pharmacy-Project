using System;
using Model;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using PharmacyProject.DTOs;

namespace Repository
{
   public class UserRepository
   {
        private String path = "Users.json";
        public List<User> users = new List<User>();

        public UserRepository()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    users = JsonConvert.DeserializeObject<List<User>>(json);
                }
            }
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(String id)
        {
            return users.Find(i => i.Id == id);
        }

        public List<User> GetAllPatients()
        {
            return users.FindAll(i => i.Role == "PATIENT");
        }

      public void SaveUser(User user)
      {
            users.Add(user);
            String json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(path, json);       
      }

       public void UpdateUserList(User user)
        {
            foreach (User usr in users)
            {
                if (usr.Id == user.Id)
                {
                    usr.ShoppingChart = user.ShoppingChart;
                    usr.Receipts = user.Receipts;
                }
            }
            String json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(path, json);
        }

    }
}