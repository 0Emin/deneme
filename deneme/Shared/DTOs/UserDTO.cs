using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme.Shared.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMailAddress { get; set; }
        public int IsActive { get; set; }
        public string Password { get; set; }
    }
}
