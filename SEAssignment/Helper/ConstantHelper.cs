using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEAssignment.Helper
{
    public class ConstantHelper
    {
        public class Employee
        {
            public const string id = "id";
            public const string password = "password";
            public const string salt = "salt";
            public const string name = "name";
            public const string email = "email";
            public const string photo = "photo";
            public const string address = "address";
            public const string bank_branch = "branch_id";
        }
        public class Bank
        {
            public const string id = "bank_id";
            public const string name = "bank_name";
        }
        public class BankBranch
        {
            public const string id = "branch_id";
            public const string name = "branch_name";
            public const string address = "address";
            public const string bank = "bank_id";
        }
    }
}