using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApp2.Models
{
    public class Robot
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual List<Session> Sessions { get; set; }
    }
}
