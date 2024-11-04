using System;
using System.ComponentModel.DataAnnotations;

namespace SWP_Project.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }  
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ShowDate { get; set; }
        public string? Location {  get; set; }
        public decimal? Price { get; set; }
        public bool? IsHot { get; set; }

        public string? ImageUrl { get; set; }
        public int? Seats { get; set; }
    }
}
