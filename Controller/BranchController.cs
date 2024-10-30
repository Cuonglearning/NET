using BankDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankDB.Controllers
{
    public class BranchController : IController1
    {
        private BankDBContext _dbContext;

        public BranchController()
        {
            //_dbContext = new BankDBContext(new DbContextOptions<BankDBContext>());
        }

        // List of items for IController1
        public List<IModel> Items => _dbContext.Branches.Cast<IModel>().ToList();

        // Create (Add new branch)
        public bool Create(IModel model)
        {
            var branch = model as Branch;
            if (branch != null)
            {
                // Validate the branch object before saving
                if (branch.IsValid())
                {
                    _dbContext.Branches.Add(branch); // Save changes to the database
                    return true;
                }
                else
                {
                    // Log or return a message indicating invalid data
                    //Console.WriteLine("Branch information is not valid.");
                    return false;
                }
            }
            return false;
        }

        // Read branch by ID
        public IModel Read(object id)
        {
            var branchId = id as string;
            return _dbContext.Branches.Find(branchId);
        }

        // Update existing branch
        public bool Update(IModel model)
        {
            var updatedBranch = model as Branch;
            if (updatedBranch != null)
            {
                var branch = _dbContext.Branches.FirstOrDefault(b => b.Id == updatedBranch.Id);
                if (branch != null)
                {
                    if (branch.IsValid())
                    {
                        branch.Name = updatedBranch.Name;
                        branch.HouseNo = updatedBranch.HouseNo;
                        branch.City = updatedBranch.City;

                        _dbContext.Branches.Update(branch); // Save changes to the database
                        return true;
                    }
                }
            }
            return false;
        }

        // Delete branch by ID
        public bool Delete(object id)
        {
            var branchId = id as string;
            var branch = _dbContext.Branches.FirstOrDefault(b => b.Id == branchId);
            if (branch != null)
            {
                _dbContext.Branches.Remove(branch); // Save changes to the database
                return true;
            }
            return false;
        }

        // Load all branches
        public bool Load()
        {
            var branches = _dbContext.Branches.ToList();
            return branches;
        }

        // Load branch by ID
        public bool Load(object id)
        {
            var customerId = id as string;

            // Kiểm tra nếu khách hàng có tồn tại
            var customer = _dbContext.Branches.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                // Xóa danh sách hiện tại và thêm khách hàng đã tìm thấy vào Items
                Items.Clear();
                Items.Add(customer);
                return true; // Trả về true nếu tìm thấy khách hàng
            }

            return false; // Trả về false nếu không tìm thấy
        }

        // Check if branch exists by ID
        public bool IsExist(object id)
        {
            var branchId = id as string;
            return _dbContext.Branches.Any(b => b.Id == branchId);
        }

        // Check if branch exists using IModel
        public bool IsExist(IModel model)
        {
            var branch = model as Branch;
            if (branch != null)
            {
                return _dbContext.Branches.Any(b => b.Id == branch.Id);
            }
            return false;
        }
    }
}
