using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoroscopServer
{
    public class ZodiacDb : DbContext
    {
        public ZodiacDb() : base("Conn")
        {
        }
        public DbSet<Zodiac> Zodiacs { get; set; }
    }
}
