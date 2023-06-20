using Practical_11.Models;

namespace Practical_11.Services.Interfaces
{
    public interface IEmployee
    {
        Employee GetSingleEmployee(int id);
        List<Employee> GetEmployees();
        int GetEmployeesCount();
        void AddOrUpdateEmployee(int id, Employee employeeData);
        void RemoveEmployee(int id);
    }
}
