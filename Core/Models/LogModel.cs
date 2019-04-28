using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class LogModel
    {
        public int ID { get; set; }

        [DisplayName("Name")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
