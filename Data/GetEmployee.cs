using Practical_11.Models;

namespace Practical_11.Data
{
    public class GetEmployee
    {
        public static List<Employee> Employees = new List<Employee>();
        static GetEmployee()
        {
            Employees.Add(new Employee()
            {
                Id = 1,
                Name = "Test",
                Address = "Test",
                Dob = Convert.ToDateTime("03/03/2003")
            });
            Employees.Add(new Employee()
            {
                Id = 2,
                Name = "Test2",
                Address = "Test2",
                Dob = Convert.ToDateTime("03/03/2003")
            });
            Employees.Add(new Employee()
            {
                Id = 3,
                Name = "Test3",
                Address = "Test3",
                Dob = Convert.ToDateTime("03/03/2003")
            });
        }        
    }
}
