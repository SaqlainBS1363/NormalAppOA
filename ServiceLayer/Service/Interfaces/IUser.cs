using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Interfaces
{
    public interface IUser
    {
        //Get All Records
        List<User> GettAllRepo();

        //Get Single Record
        User GetSingleRepo(int id);

        //Add Record
        string AddUserRepo(User user);

        //Update or Edit Record
        string UpdateUserRepo(User user);

        //Delete Record
        string DeleteUserRepo(int id);
    }
}
