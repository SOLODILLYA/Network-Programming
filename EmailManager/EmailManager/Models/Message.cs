using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailManager.Models
{
    internal class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public DateTime SentDate { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
