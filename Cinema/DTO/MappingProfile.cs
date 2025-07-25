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

            CreateMap<MovieCreateDTO,Movie>()
                .ForMember(dest=>dest.Genre,opt=>
                opt.MapFrom(src=>Enum.Parse<Genre>(src.Genre,true)));
            
            CreateMap<Movie, MovieReadDTO>()
                .ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.ToString()));
            CreateMap<MovieUpdateDTO,Movie>()
                .ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>Enum.Parse<Genre>(src.Genre,true)));
          

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

            CreateMap<RoleDTO, Role>().ReverseMap();
            CreateMap<Role, RoleDTORead>()
                .ForMember(dest => dest.GetUsers, opt => opt.MapFrom(src => src.Users));
            CreateMap<RoleDTORead, Role>()
                .ForMember(dest => dest.Users, opt => opt.Ignore());
            CreateMap<RoleDTOUpdate, Role>().ReverseMap();

            CreateMap<User,UserUpdateDto>().ReverseMap();
            CreateMap<User, UserReadDTO>().ReverseMap();

          
        }

    }
}
