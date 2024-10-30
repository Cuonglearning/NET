
using BankDB.Models;
using System.Collections.Generic;
using System.Linq;

public class EmployeeController : IController1
{
    private BankDBContext _context;

    public EmployeeController()
    {
        _context = new BankDBContext(new DbContextOptions<BankDBContext>());
    }

    // List of items for IController1
    public List<IModel> Items => _context.Employees.Cast<IModel>().ToList();

    // Register a new employee
    public bool Register(string role, string password, string email)
    {
        // Check if email already exists in the system
        if (_context.Employees.Any(e => e.Email == email))
        {
            return false; // Email already exists
        }
        
        // Create a new employee
        Employee newEmployee = new Employee
        {
            Id = "1",// Generate a unique ID
            Role = "NV",
            Password = password, // Consider hashing the password before saving
            Email = email
        };
        if (newEmployee.IsValid())
        {
            return false;
        }
        _context.Employees.Add(newEmployee);
        _context.SaveChanges();
        return true; // Registration successful
    }

    // Login
    public string Login(string email, string password)
    {
        // Find employee by email
        var employee = _context.Employees.FirstOrDefault(e => e.Email == email);

        if (employee != null && employee.Password == password) // Directly compare passwords
        {
            if (employee.IsValid())
            {
                return employee.Role; 
            }
           
        }

        return null; // Login failed
    }

    // Create (Add new employee)
    public bool Create(IModel model)
    {
        var employee = model as Employee;
        if (employee != null)
        {
            // Validate the employee object before saving
            if (employee.IsValid())
            {
                _context.Employees.Add(employee);
                _context.SaveChanges(); // Save changes to the database
                return true;
            }
            else
            {
                // Log or return a message indicating invalid data
                Console.WriteLine("Employee information is not valid.");
                return false;
            }
        }
        return false;
    }

    // Read employee by ID
    public IModel Read(object id)
    {
        var employeeId = id as string;
        return _context.Employees.Find(employeeId);
    }

    // Update existing employee
    public bool Update(IModel model)
    {
        var updatedEmployee = model as Employee;
        if (updatedEmployee != null)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (employee != null)
            {
                if (employee.IsValid())
                {
                    employee.Password = updatedEmployee.Password;
                    employee.Role = updatedEmployee.Role;
                    employee.Email = updatedEmployee.Email;

                    _context.Employees.Update(employee);
                    _context.SaveChanges(); // Save changes to the database
                    return true;
                }
               
            }
        }
        return false;
    }

    // Delete employee by ID
    public bool Delete(object id)
    {
        var employeeId = id as string;
        var employee = _context.Employees.FirstOrDefault(e => e.Id == employeeId);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges(); // Save changes to the database
            return true;
        }
        return false;
    }

    // Load all employees
    public bool Load()
    {
        var employees = _context.Employees.ToList();
        return employees.Count > 0;
    }

    // Load employee by ID
    public bool Load(object id)
    {
        var customerId = id as string;

        // Kiểm tra nếu khách hàng có tồn tại
        var customer = _context.Employees.FirstOrDefault(c => c.Id == customerId);
        if (customer != null)
        {
            // Xóa danh sách hiện tại và thêm khách hàng đã tìm thấy vào Items
            Items.Clear();
            Items.Add(customer);
            return true; // Trả về true nếu tìm thấy khách hàng
        }

        return false; // Trả về false nếu không tìm thấy
    }

    // Check if employee exists by ID
    public bool IsExist(object id)
    {
        var employeeId = id as string;
        return _context.Employees.Any(e => e.Id == employeeId);
    }

    // Check if employee exists using IModel
    public bool IsExist(IModel model)
    {
        var employee = model as Employee;
        if (employee != null)
        {
            return _context.Employees.Any(e => e.Id == employee.Id);
        }
        return false;
    }
}
