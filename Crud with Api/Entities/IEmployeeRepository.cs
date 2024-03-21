namespace Employee_CRUD_API.Entities
{
    public interface IEmployeeRepository
    {
        public Task<bool> AddEmployeeData(Employee employee);
        public Task<bool> DeleteEmployeeData(int id);
        public Task<Employee> UpdateEmployeeData(Employee employee);
        public Task<IEnumerable<Employee>> GetAllEmployees();
        public Task<IEnumerable<Employee>>GetEmployeeDetailsById(int id);

    }

    
}
