using MySql.Data.MySqlClient;
using SEAssignment.Helper;
using SEAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using static SEAssignment.Helper.EncrytionHelper;

namespace SEAssignment.BusinessLayer
{
    public class EmployeeBL
    {
        public GetEmployeeDetailsResponse GetEmployeeDetails(string username, string pwd)
        {
            GetEmployeeDetailsResponse EmployeeDetailsResponse = new GetEmployeeDetailsResponse();
            Bank bank = new Bank();
            Branch branch = new Branch();
            Employee employee = new Employee();
            string cs = WebConfigurationManager.AppSettings["DBConnection"];

            //Auth checking
            DataTable dt_auth = new DataTable();
            MySqlConnection connection_auth = new MySqlConnection(cs);
            MySqlDataAdapter da_auth = new MySqlDataAdapter("sp_GetEmployeeHash", connection_auth);
            da_auth.SelectCommand.CommandType = CommandType.StoredProcedure;
            da_auth.SelectCommand.Parameters.Add("pid", MySqlDbType.String).Value = username;
            da_auth.Fill(dt_auth);
            string hash = string.Empty;
            string salt = string.Empty;
            foreach (DataRow row in dt_auth.Rows)
            {
                hash = row[ConstantHelper.Employee.password].ToString();
                salt = row[ConstantHelper.Employee.salt].ToString();
            }
            bool is_auth = EncrytionHelper.VerifyPassword(pwd, hash, salt);

            if (is_auth)
            {
                DataTable dt = new DataTable();
                MySqlConnection connection = new MySqlConnection(cs);
                MySqlDataAdapter da = new MySqlDataAdapter("sp_GetEmployee", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("pid", MySqlDbType.String).Value = username;
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    //employee
                    employee.Name = row[ConstantHelper.Employee.name].ToString();
                    employee.Email = row[ConstantHelper.Employee.email].ToString();
                    employee.Photo = row[ConstantHelper.Employee.photo].ToString();
                    //bank
                    bank.Name = row[ConstantHelper.Bank.name].ToString();
                    //branch
                    branch.Name = row[ConstantHelper.BankBranch.name].ToString();
                    EmployeeDetailsResponse.status = 200;
                }
                connection.Close();

                EmployeeDetailsResponse.bank = bank;
                EmployeeDetailsResponse.branch = branch;
                EmployeeDetailsResponse.employee = employee;
            }
            else { 
                    EmployeeDetailsResponse.status = 400;
            }
            return EmployeeDetailsResponse;
        }
    }
}