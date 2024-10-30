using BankDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankDB.Controllers
{
    public class CustomerController : IController1
    {
        private BankDBContext _context;

        public CustomerController()
        {
            _context = new BankDBContext(new DbContextOptions<BankDBContext>());
           
        }

        // List of items for IController1
        public List<IModel> Items { get; private set; } = new List<IModel>();

        // Create (Add new customer)
        public bool Create(IModel model)
        {
            var customer = model as Customer;
          
            if (customer != null)
            {
                customer.Id=GenerateSmallestId();
                // Đặt Id thành null trước khi chèn
                if (customer.IsValid())
                {
                    try
                    {
                        _context.Customers.Add(customer);
                        _context.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi thêm khách hàng: " + ex.Message);
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Thông tin khách hàng không hợp lệ.");
                    return false;
                }
            }

            return false;
        }
        private string GenerateSmallestId()
        {
            int smallestMissingId = 1;
            var maxId = _context.Customers.Max(c => (int?)Convert.ToInt32(c.Id)) ?? 0;

            // Tạo danh sách từ 1 đến maxId
            var numbers = Enumerable.Range(1, maxId + 1).ToList();
            var existingIds = _context.Customers.Select(c => Convert.ToInt32(c.Id)).ToList();

            // Tìm Id nhỏ nhất còn trống
            smallestMissingId = numbers.Except(existingIds).FirstOrDefault();

            return smallestMissingId.ToString();
        }

        // Read customer by ID
        public IModel Read(object id)
        {
            var customerId = id as string;
            return _context.Customers.Find(customerId);
        }

        // Update existing customer
        public bool Update(IModel model)
        {
            var updatedCustomer = model as Customer;
            if (updatedCustomer != null)
            {
                var customer = _context.Customers.FirstOrDefault(c => c.Id == updatedCustomer.Id);
                if (customer != null)
                {
                    if (customer.IsValid())
                    {
                        customer.Name = updatedCustomer.Name;
                        customer.Phone = updatedCustomer.Phone;
                        customer.Email = updatedCustomer.Email;
                        customer.HouseNo = updatedCustomer.HouseNo;
                        customer.City = updatedCustomer.City;
                        customer.Pin = updatedCustomer.Pin;

                        _context.Customers.Update(customer);
                        _context.SaveChanges(); // Save changes to the database
                        return true;
                    }
                   
                }
            }
            return false;
        }

        // Delete customer by ID
        public bool Delete(object id)
        {
            var customerId = id as string;
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges(); // Save changes to the database
                return true;
            }
            return false;
        }
   
        // Load all customers
        public bool Load()
        {
            try
            {
                // Tải toàn bộ danh sách từ bảng Customers và gán vào thuộc tính Customers
                Items = _context.Customers.Cast<IModel>().ToList();
                // Trả về true nếu danh sách không rỗng
                return Items.Count > 0;
            }
            catch (Exception ex)
            {

                Items = new List<IModel>();

                // Log lỗi (tuỳ chọn) hoặc xử lý lỗi tại đây
                Console.WriteLine("Lỗi khi tải dữ liệu: " + ex.Message);

                return false;
            }
        }

        // Load customer by ID
        public bool Load(object id)
        {
            var customerId = id as string;

            // Kiểm tra nếu khách hàng có tồn tại
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                // Xóa danh sách hiện tại và thêm khách hàng đã tìm thấy vào Items
                Items.Clear();
                Items.Add(customer);
                return true; // Trả về true nếu tìm thấy khách hàng
            }

            return false; // Trả về false nếu không tìm thấy
        }

        // Check if customer exists by ID
        public bool IsExist(object id)
        {
            var customerId = id as string;
            return _context.Customers.Any(c => c.Id == customerId);
        }

        // Check if customer exists using IModel
        public bool IsExist(IModel model)
        {
            var customer = model as Customer;
            if (customer != null)
            {
                return _context.Customers.Any(c => c.Id == customer.Id);
            }
            return false;
        }
    }
}
