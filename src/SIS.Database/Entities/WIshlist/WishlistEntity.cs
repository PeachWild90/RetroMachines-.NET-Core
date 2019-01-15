using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RedStarter.Database.Entities.WIshlist
{
    public class WishlistEntity
    {
        [Key]
        public int TransactionalId { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
