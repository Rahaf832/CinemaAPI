using CinemaAPI.Models;
using AutoMapper;
using CinemaAPI.DTO.CreateDTO;
using CinemaAPI.DTO.ReadDTO;
using CinemaAPI.DTO.UpdateDTO;
using CinemaAPI.DTO.UserDTO;
using CinemaAPI.DTO.ShowTimeSeatDTO;
 
namespace CinemaAPI.DTO
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Booking, BookingCreate>().ReverseMap();
            CreateMap<Booking, BookingUpdate>().ReverseMap();
            CreateMap<Booking,BookingRead>().ReverseMap();

            CreateMap<Movie,MovieCreateDTO>().ReverseMap();
            CreateMap<Movie, MovieReadDTO>().ReverseMap();
            CreateMap<Movie, MovieUpdateDTO>().ReverseMap();

            CreateMap<Seat, SeatCreate>().ReverseMap();
            CreateMap<Seat, SeatRead>().ReverseMap();
            CreateMap<Seat, SeatUpdate>().ReverseMap();

            CreateMap<ShowTime, ShowTimeCreate>().ReverseMap();
            CreateMap<ShowTime, ShowTimeRead>().ReverseMap();
            CreateMap<ShowTime, ShowTimeUpdate>().ReverseMap();

            CreateMap<Theater, TheaterCreateDTO>().ReverseMap();
            CreateMap<Theater, TheaterReadDTO>().ReverseMap();
            CreateMap<Theater, TheaterUpdateDTO>().ReverseMap();

            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserRegisterDTO>().ReverseMap();

            CreateMap<ShowTimeSeat, DetailsDTO>().ReverseMap();

        }

    }
}
