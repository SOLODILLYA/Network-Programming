using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class MyResponse
    {
        public string Message { get; set; }
        public List<MyTask> MyTasks { get; set; }
    }
}
