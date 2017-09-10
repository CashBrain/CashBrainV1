using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo
{
    public class EmployeeSecurity
    {
        public static bool Login(string UserName, string Password)
        {
            bool isSuccess = false;
            try
            {
                EmployeeDB objEmployeeDB = new EmployeeDB();
                isSuccess = objEmployeeDB.ValidateUserCredentails(UserName,Password);
            }
            catch (Exception ex)
            {

            }
            return isSuccess;
        }
    }
}