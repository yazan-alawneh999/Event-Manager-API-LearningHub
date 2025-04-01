using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Core.Response;
using Microsoft.Extensions.Logging;

namespace LearningHub.Core.Dto
{
    public class EventWithFeedBackDto
    {
        public decimal EVENTID  { get; set; }
        public string EventName { get; set; }
      
        public double CAPACITY { get; set; }

        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public List<ProfileDto> ProfileDto { get; set; } = new List<ProfileDto>();


    }
}
