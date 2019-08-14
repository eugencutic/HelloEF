﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApp2.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RobotId { get; set; }
        [ForeignKey("Robot")]
        public virtual Robot Robot { get; set; }

    }
}