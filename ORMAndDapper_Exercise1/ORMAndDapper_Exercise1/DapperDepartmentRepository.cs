using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMAndDapper_Exercise1
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _conn;

        public DapperDepartmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        //Methods for accessing the database stored here
        public IEnumerable<Department> GetAllDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments"); /*this string is what will be run inside the SQL db,
                                                                            data will be returned as type 'department' */
        }
        public void InsertDepartment(string name)
        {
            _conn.Execute("INSERT INTO departments (Name) VALUES (@name)",
                new { name });
        }

        
    }
}
