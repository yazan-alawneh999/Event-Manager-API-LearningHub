using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Response
{
      public class Notification
      {
        public decimal ID { get; set; }
        public decimal userId { get; set; }
        public string message { get; set; } 
        public  DateTime createdAt{ get; set; }
      
    }
}
