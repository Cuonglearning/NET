using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace view
{
    public interface IView
    {
        // Thiết lập dữ liệu từ object vào các trường của form
        void SetDataToText(object item);

        // Lấy dữ liệu từ các trường của form và trả về đối tượng
        object GetDataFromText();
    }
}
