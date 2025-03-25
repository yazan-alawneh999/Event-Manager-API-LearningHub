using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Core.Dto;

namespace LearningHub.Core.Response
{
   public  class EventModel
    {

        public int Id { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }

        [Required]
        public int OrganizerID { get; set; }

        [Required]
        [StringLength(200)]
        public string EventName { get; set; }

        [StringLength(100)]
        public string EventType { get; set; }

        [Required]
        public DateTime EventTime { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        [StringLength(50)]
        public string EventStatus { get; set; }

        [StringLength(1200)]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // علاقة مع جدول Users
        [ForeignKey("OrganizerID")]
        public virtual User Organizer { get; set; }
    }


}

