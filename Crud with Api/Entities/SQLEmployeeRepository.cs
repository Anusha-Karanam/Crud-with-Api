using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Emit;


namespace Employee_CRUD_API.Entities
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public SQLEmployeeRepository(EmployeeDbContext context)
        {

            _context = context;
        }





        public async Task<bool> AddEmployeeData(Employee employee)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync(
                    @"EXEC AddNewEmployee @FirstName, @LastName, @DateofBirth, @Address, @City, @StateCode, @ZipCode, @PhoneNumber, @Email, @Salary, @DepartmentId",
                    new SqlParameter("@FirstName", employee.FirstName),
                    new SqlParameter("@LastName", employee.LastName),
                    new SqlParameter("@DateofBirth", employee.DateOfBirth),
                    new SqlParameter("@Address", employee.Address),
                    new SqlParameter("@City", employee.City),
                    new SqlParameter("@StateCode", employee.StateCode),
                    new SqlParameter("@ZipCode", employee.ZipCode),
                    new SqlParameter("@PhoneNumber", employee.PhoneNumber),
                    new SqlParameter("@Email", employee.Email),
                    new SqlParameter("@Salary", employee.Salary),
                    new SqlParameter("@DepartmentId", employee.DepartmentId));


                return result > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> DeleteEmployeeData(int id)
        {
            int i = await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"DeleteEmployeeByID {id}"));
            if (i == 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees.FromSqlRaw("EXEC GetEmployeeList").ToListAsync();
        }

 

        public async Task<IEnumerable<Employee>> GetEmployeeDetailsById(int id)
        {
            try
            {
                var param = new SqlParameter("@id", id);

                var employeedet = await _context.Employees
                    .FromSqlRaw(@"exec GetEmployeebyID @id", param)
                    .ToListAsync();
                if(employeedet.Count == 0)
                {
                    throw new EmployeeNotFoundException($"Employee with ID {id} not found");
                }
                return employeedet;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred:Id not found");
                throw;
            }
        }

        public async Task<Employee> UpdateEmployeeData(Employee employee)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    @"EXEC UpdateEmployee @id, @FirstName, @LastName, @DateofBirth, @Address, @City, @StateCode, @ZipCode, @PhoneNumber, @Email, @Salary, @DepartmentId",
                    new SqlParameter("@id", employee.Id),
                    new SqlParameter("@FirstName", employee.FirstName),
                    new SqlParameter("@LastName", employee.LastName),
                    new SqlParameter("@DateofBirth", employee.DateOfBirth),
                    new SqlParameter("@Address", employee.Address),
                    new SqlParameter("@City", employee.City),
                    new SqlParameter("@StateCode", employee.StateCode),
                    new SqlParameter("@ZipCode", employee.ZipCode),
                    new SqlParameter("@PhoneNumber", employee.PhoneNumber),
                    new SqlParameter("@Email", employee.Email),
                    new SqlParameter("@Salary", employee.Salary),
                    new SqlParameter("@DepartmentId", employee.DepartmentId));

                return employee;
            }
            catch (Exception ex)
            {
              
                return null;
            }
        }


    }
}

public class EmployeeNotFoundException : Exception
{
    public EmployeeNotFoundException(string message) : base(message) { }
}