﻿using System;
using System.Collections.Generic;

namespace CinemaAppBackend.Models
{
    public partial class Admin
    {
        public ushort IdAdmin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal? PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
    }
}