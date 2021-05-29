using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using SEAssignment.BusinessLayer;
using SEAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace SEAssignment.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("GetYes")]
        public string GetYes()
        {
            return "YES";
        }

        [HttpGet]
        [Route("GetEmployeeDetail")]
        public GetEmployeeDetailsResponse GetEmployeeDetail(string username,string pwd)
        {
            EmployeeBL EmployeeBL = new EmployeeBL();
            return EmployeeBL.GetEmployeeDetails(username,pwd);
        }

    }
}