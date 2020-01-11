﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Interfaces
{
    interface IScreeningsRepository
    {
        IEnumerable<Screenings> GetScreenings();
        Screenings GetScreening(int id);
    }
}
