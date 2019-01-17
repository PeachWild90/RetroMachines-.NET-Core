using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace RedStarter.Database.Entities.Product
{
    public class ProductEntity
    {
        [Key]
        public int ProductEntityId { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Condition { get; set; }

        [Required]
        public DateTimeOffset DateCreated { get; set; }
    }
}
