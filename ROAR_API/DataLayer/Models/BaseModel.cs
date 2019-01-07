using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        
        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime CancelDate { get; set; }

        public bool IsDeleted { get; set; }

        public BaseModel()
        {
            CreationDate = DateTime.Now;
        }

    }
}
