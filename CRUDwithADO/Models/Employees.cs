using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDwithADO.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }
        public string Mobile { get; set; }
        public string Gender{ get; set; }
        public int DeptId { get; set; }
        public string DName { get; set; }
    }
}
