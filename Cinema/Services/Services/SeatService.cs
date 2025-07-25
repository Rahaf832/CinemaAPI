using Microsoft.EntityFrameworkCore;
using CinemaAPI.DTO.CreateDTO;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.UpdateDTO;
using CinemaAPI.Models;
using CinemaAPI.Services.Interfaces;
using CinemaAPI.Data;
using AutoMapper;

namespace CinemaAPI.Services.Services
{
    public class SeatService:ISeat
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public SeatService (IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<SeatRead>> GetSeats()
        {
            var Seats= await _context.Seats
                .Include(s=>s.ShowTimeSeats)
                .ToListAsync();
            var resualt= _mapper.Map<List<SeatRead>>(Seats);
            return resualt;
        }
        public async Task<SeatRead> GetSeatById(int id)
        {
            var seat = await _context.Seats
                .Include(s => s.ShowTimeSeats)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (seat == null) { return null; }
            var resualt=_mapper.Map<SeatRead>(seat);
            return resualt;
        }
        public async Task<int> AddSeat(SeatCreate seatCreat)
        {
            var seat=_mapper.Map<Seat>(seatCreat);
            await _context.Seats.AddAsync(seat);

            await _context.SaveChangesAsync();
            return seat.Id;

        }
        public async Task<bool>UpdateSeat(int id,SeatUpdate seatUpdate)
        {
            var seat = await _context.Seats.FirstOrDefaultAsync(s => s.Id == id);
            if(seat == null) { return false; }
            seat.SeatNumber = seatUpdate.SeatNumber;
            seat.TheaterId = seatUpdate.TheaterID;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool>DeleteSeat(int id)
        {
            var seat = await _context.Seats.FirstOrDefaultAsync(s => s.Id == id);
            if (seat == null) { return false; }
            _context.Seats.Remove(seat);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
