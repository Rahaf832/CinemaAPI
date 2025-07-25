using CinemaAPI.DTO.CreateDTO;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.UpdateDTO;

namespace CinemaAPI.Services.Interfaces
{
    public interface ISeat
    {
        Task<List<SeatRead>> GetSeats();
        Task<SeatRead> GetSeatById(int seatId);
        Task<int> AddSeat(SeatCreate seatCreate);
        Task<bool> UpdateSeat(int id, SeatUpdate seatUpdate);
        Task<bool> DeleteSeat(int id);
    }
}
