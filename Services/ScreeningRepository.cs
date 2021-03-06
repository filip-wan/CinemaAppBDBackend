﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CinemaAppBackend.Services
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly dbContext _context;

        public ScreeningRepository(dbContext context)
        {
            _context = context;
        }

        public IEnumerable<Screening> GetScreenings()
        {
            var screenings = _context.Screenings.AsNoTracking().Include("Film").ToList();
            screenings.ForEach(s => s.Film.Screenings = null);
            return screenings;
        }

        public Screening GetScreening(int id)
        {
            // TODO changed
            var screening = _context.Screenings.AsNoTracking().Include("Film").Include("Screenseats.Seat").Include("Price").First(s => s.Id == id);
            screening.Film.Screenings = null;
            var seats = screening.Screenseats.ToList();
            seats.ForEach(s =>
            {
                s.Tickets = null;
                s.Screening = null;
                s.Seat.Screenseats = null;
            });
            screening.Screenseats = seats;
            screening.Price.Screenings = null;
            return screening;
        }
    }
}
