using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMAndDapper_Exercise1
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        //Methods for accessing the database stored here
        public IEnumerable<Department> GetAllDepartments()
        {
            throw new NotImplementedException();
        }
    }
}
