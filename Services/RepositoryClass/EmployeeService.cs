using Practical_11.Data;
using Practical_11.Models;
using Practical_11.Services.Interfaces;

namespace Practical_11.Services.RepositoryClass
{
    public class EmployeeService : IEmployee
    {
        public List<Employee> GetEmployees()
        {
            var data = GetEmployee.Employees;
            return data;
        }
        public int GetEmployeesCount()
        {
            int count = GetEmployee.Employees.Count;
            return count;
        }
        public Employee GetSingleEmployee(int id)
        {
            var data = GetEmployee.Employees.Find(x => x.Id == id);
            return data;
        }        
        public void AddOrUpdateEmployee(int id, Employee employeeData)
        {
            var data = GetSingleEmployee(id);
            if(data != null)
            {
                data.Name = employeeData.Name;
                data.Address = employeeData.Address;
                data.Dob = employeeData.Dob;
            }
            else
                GetEmployee.Employees.Add(employeeData);
        }
        public void RemoveEmployee(int id)
        {
            var data = GetSingleEmployee(id);
            GetEmployee.Employees.Remove(data);
        }
    }
}
