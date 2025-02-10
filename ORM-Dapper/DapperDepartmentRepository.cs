using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _conn;     //Connection 

        public DapperDepartmentRepository(IDbConnection connection)   //Constructor
        {
            _conn = connection;
        }

        public IEnumerable<Department> GetAllDepartments()  //Get all deparments
        { 
            return _conn.Query<Department>("SELECT * FROM Departments;");
        }

        public void InsertDepartment(string newDepartmentName)  //Insert new department
        {
            _conn.Execute("INSERT INTO departments (Name) VALUES (@departmentName)", new { departmentName = newDepartmentName });
        }
    }
}
