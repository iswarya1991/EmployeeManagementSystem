using System.Collections.Generic;

namespace EMS.Business.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<EmployeeModel> Employees { get; set; }
    }
}
