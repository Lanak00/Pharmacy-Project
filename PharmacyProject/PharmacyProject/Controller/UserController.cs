using System;
using System.Collections.Generic;
using Model;
using Service;

namespace Controller
{
   public class UserController
   {
        public UserService userService = new UserService();

        public bool Login(string id, string password)
        {
            return userService.Login(id, password);
        }

        public List<User> GetAllPatients()
        {
            return userService.GetAllPatients();
        }

        public List<User> SortPatientsByFirstName()
        {
            return userService.SortPatientsByFirstName();
        }

        public List<User> SortPatientsByLastName()
        {
            return userService.SortPatientsByLastName();
        }

        public void SaveUser(User user)
        {
            userService.SaveUser(user);
        }

        public void UpdateUserList(User user)
        {
            userService.UpdateUserList(user);
        }


    }
}