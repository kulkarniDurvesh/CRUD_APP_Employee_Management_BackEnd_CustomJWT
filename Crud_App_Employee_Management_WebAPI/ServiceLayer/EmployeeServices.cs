using Models;
using RepositoryLayer;

namespace ServiceLayer
{
    public class EmployeeServices
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeServices(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeClass>> GetAllEmployessList() {
            //return await _employeeRepository.GetAllEmployees();
            var employees = await _employeeRepository.GetAllEmployees();
            Console.WriteLine($"Fetched {employees.Count} employees.");
            return employees;

        }

        public async Task<List<EmployeeClass>> GetAllEmployeesByAge(int age) {
            return await _employeeRepository.GetAllEmployeesByAge(age);
        }

        public  async Task<EmployeeDTO> AddEmployee(EmployeeClass employee) 
        {
            return await _employeeRepository.AddEmployee(employee);
        }
        public async Task<EmployeeClass> UpdateEmployeeDetails(EmployeeClass employee)
        {
            return await _employeeRepository.UpdateEmployeeDetails(employee);
        }

        public List<EmployeeWithGrade> GetEmployeeByGradeName(string gradeName)
        {
            return _employeeRepository.GetEmployeeByGradeName(gradeName);
        }

        public int UpdateEmployeeData() 
        {
            return _employeeRepository.UpdateEmployeeData();
        }
    }
}
