using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class MyRequest
    {
        public string Header { get; set; }
        public User AuthUser { get; set; }
        public User RegistryUser { get; set; }
        public MyTask NewTask { get; set; }
        public MyTask EditTask { get; set; }
        public int DelTaskId { get; set; }
    }
}
