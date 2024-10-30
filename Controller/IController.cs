using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Controller
{
        public interface IController<T>
        {
            // Thêm mới một đối tượng
            void Add(T entity);

            // Lấy danh sách tất cả các đối tượng
            List<T> GetAll();

            // Tìm kiếm đối tượng theo ID
            T GetById(string id);

            // Cập nhật đối tượng
            void Update(T entity);

            // Xóa đối tượng theo ID
            void Delete(string id);
        }
}
