using System;
using Model;
using System.Collections.Generic;
using PharmacyProject;
using PharmacyProject.DTOs;
using System.Linq;
using Repository;

namespace Service
{
   public class UserService
   {

        public UserRepository userRepository = new UserRepository();

        public bool Login(string id, string password)
        {
            return SetLoggedUser(id, password);
        }

        public bool SetLoggedUser(string id, string password)
        {
            List<User> users = userRepository.GetAllUsers();
            foreach (User user in users)
            {
                if (user.Id == id && user.Password == password)
                {
                    Globals.LoggedUser = user;
                    return true;
                }
            }
            return false;
        }

        public List<User> GetAllPatients()
        {
            return userRepository.GetAllPatients();
        }
   
        public List<User> SortPatientsByFirstName()
        {
            return userRepository.GetAllPatients().OrderBy(patient => patient.FirstName).ToList();
        }

        public List<User> SortPatientsByLastName()
        {
            return userRepository.GetAllPatients().OrderBy(patient => patient.LastName).ToList();
        }

        public void SaveUser(User user)
        {
            userRepository.SaveUser(user);
        }

        public void UpdateUserList(User user)
        {
            userRepository.UpdateUserList(user);
        }
    }
}