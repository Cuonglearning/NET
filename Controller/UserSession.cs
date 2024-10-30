using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Controller
{
    public static class UserSession
    {
        public static string CurrentUserRole { get; set; } = null;

        public static void SetUserRole(string userRole)
        {
            CurrentUserRole = userRole;
        }
        public static string ID { get; set; } = null;
        public static void SetCustomerId(string id)
        {
            ID = id;
        }
    }
}
