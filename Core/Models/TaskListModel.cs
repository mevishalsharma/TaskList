using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class TaskListModel
    {
        public int ID { get; set; }
        [DisplayName("Task")]
        [Required]
        public string TaskHead{ get; set; }
        [DisplayName("Description")]
        [Required]
        public string TaskDescription { get; set; }
        [DisplayName("Last Update")]
        public DateTime UpdatedDate { get; set; }
        public int TaskUserId { get; set; }
        [DisplayName("Task Checked")]
        public Boolean TaskChecked { get; set; }
    }
}
