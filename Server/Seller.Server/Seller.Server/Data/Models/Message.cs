﻿namespace Seller.Server.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string SenderId { get; set; }
        [Required]
        public User Sender { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Created { get; set; }

        public bool IsDeleted { get; set; }
    }
}
