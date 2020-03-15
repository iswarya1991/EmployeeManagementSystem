using EMS.Business.Models;
using EMS.Data;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Business
{
    public class EMSLogic
    {
        private EMSEntities _EMSContext;
        public EMSLogic()
        {
            _EMSContext = new EMSEntities();
        }

        public void CreateDepartment(Department department)
        {
            if (department != null)
            {
                _EMSContext.Departments.Add(department);
                _EMSContext.SaveChanges();
            }
        }
        public string CreateEmployee(Employee employee)
        {
            if(employee != null)
            {
                var deptId = _EMSContext.Departments.Any(x => x.Id == employee.DeptId);
                if (deptId)
                {
                    _EMSContext.Employees.Add(employee);
                    _EMSContext.SaveChanges();
                    return "Ëmployee added successfully!";
                }
                else
                {
                    return "No department exists";
                }
            }
            return "employee shoud not be null";
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {
           return  _EMSContext.Employees.Select(_ => new EmployeeModel { 
            Id = _.Id,
            Name = _.Name,
            Address = _.Address,
            DepartmentName =_.Department.Name
           }).ToList();
        }

        public EmployeeModel GetEmployeeById(int id)
        {
           return _EMSContext.Employees.Select(_ => new EmployeeModel { 
             Id = _.Id,
             Name = _.Name,
             Address = _.Address,
             DepartmentName = _.Department.Name
           }).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<DepartmentModel> GetDepartments()
        {
            return _EMSContext.Departments.Select(dept => new DepartmentModel { 
             Id = dept.Id,
             Name = dept.Name,
             Employees = dept.Employees.Select(_=> new EmployeeModel { 
              Id = _.Id,
              Name = _.Name,
              Address = _.Address
             }).ToList()
            }).ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _EMSContext.Departments.FirstOrDefault(x => x.Id == id);
        }

        public string UpdateEmployee(int id, Employee employee)
        {
            var emp = _EMSContext.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null) return "No empoyee to update!";
            if (!string.IsNullOrEmpty(employee.Name))
            {
                emp.Name = employee.Name;
            }
            if (!string.IsNullOrEmpty(employee.Address))
            {
                emp.Address = employee.Address;
            }
            if(employee.DeptId > 0)
            {
                emp.DeptId = employee.DeptId;
            }
            _EMSContext.SaveChanges();
            return $"employee updated successfully!";
        }

        public string UpdateDepartment(Department department)
        {
            var dept = _EMSContext.Departments.FirstOrDefault(x => x.Id == department.Id);
            if (dept == null) return "No department to update!";
            dept.Name = department.Name;
            _EMSContext.SaveChanges();
            return $"{department.Name} updated succesfully";
        }

        public string DeleteEmployee(int id)
        {
            var employee = _EMSContext.Employees.FirstOrDefault(x => x.Id == id);
            if(employee != null)
            {
                _EMSContext.Employees.Remove(employee);
                _EMSContext.SaveChanges();
                return "employee deleted successfully!";
            }
            return "No employee to delete!";
        }
        public string DeleteDepartment(int id)
        {
            var department = _EMSContext.Departments.FirstOrDefault(x => x.Id == id);
            if(department != null)
            {
                _EMSContext.Departments.Remove(department);
                _EMSContext.SaveChanges();

                return "department deleted successfully!";
            }
            return "No department to delete";
        }
    }
}
