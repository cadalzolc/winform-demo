using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadalzo.demo
{
    public class User
    {
        public string ID { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Name { get; set; } = "";
        public string Status { get; set; } = "";
        public string Last_Login { get; set; } = "";
        public string Status_Description 
        { 
            get
            {
                switch (Status)
                {
                    case "A": return "Active";
                    case "L": return "Locked";
                    default: return "Not Activated";
                }
            }
        }
    }
}