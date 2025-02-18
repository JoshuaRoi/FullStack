﻿using System;
using System.ComponentModel.DataAnnotations;


namespace ContactsAPI.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public bool IsFavorite { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }

    }
}
