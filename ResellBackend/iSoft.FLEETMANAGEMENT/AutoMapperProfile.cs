using AutoMapper;
using ResellBackendCore.Database.Dtos.CategoryDto;
using ResellBackendCore.Database.Dtos.MatchDto;
using ResellBackendCore.Database.Dtos.StatisticsDto;
using ResellBackendCore.Database.Dtos.TicketDto;
using ResellBackendCore.Database.Dtos.TicketMatchDto;
using ResellBackendCore.Database.Dtos.UserDto;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.FLEETMANAGEMENT.Backend.Core.Utils
{
    public class AutoMapperProfile : Profile
    {
       
        public AutoMapperProfile()
        {
            


            CreateMap<AddUserDto, User>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<AddUserDto, GetUserDto>().ReverseMap();

            CreateMap<AddCategoryDto, Category>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<AddCategoryDto, GetCategoryDto>().ReverseMap();

            CreateMap<Team, GetCategoryDto>().ReverseMap();


            CreateMap<Ticket, GetTicketDto>();
            CreateMap<Ticket, GetTicketDto>()
            .ForMember(dest => dest.Matches, opt => opt.MapFrom(src => src.Matches.Select(tm => new ListTicketMatchDto
            {
                MatchId = tm.MatchId,
                Match = new GetMatchDto
                {
                    Id = tm.Match.Id,
                    HomeTeamId = tm.Match.HomeTeamId,
                    AwayTeamId = tm.Match.AwayTeamId,
                    League = tm.Match.League,
                    Tip = tm.Match.Tip,
                    Odd = tm.Match.Odd,
                    StartTime = tm.Match.StartTime
                }
            }).ToList()));
            CreateMap<AddTicketDto, Ticket>().ReverseMap();
            CreateMap<AddTicketDto, GetTicketDto>().ReverseMap();


            CreateMap<Match, GetMatchDto>().ReverseMap();
            CreateMap<AddMatchDto, Match>().ReverseMap();
            CreateMap<AddMatchDto, GetMatchDto>().ReverseMap();

            CreateMap<TicketMatch, GetTicketMatchDto>().ReverseMap();
            CreateMap<AddTicketMatchDto, TicketMatch>().ReverseMap();
            CreateMap<AddTicketMatchDto, GetTicketMatchDto>().ReverseMap();

            CreateMap<Ticket, GetTicketDto>()
    .ForMember(dest => dest.Matches, opt => opt.MapFrom(src => src.Matches))
    .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<Ticket, GetTicketDto>()
                .ForMember(dest => dest.Matches, opt => opt.MapFrom(src => src.Matches.Select(tm => tm.Match)));
            CreateMap<TicketMatch, ListTicketMatchDto>();

            CreateMap<AddStatisticsDto, Statistics>().ReverseMap();
            CreateMap<Statistics, GetStatisticsDto>()
                 .ForMember(dest => dest.CategoryDto, opt => opt.MapFrom(src => src.Category));
            CreateMap<AddStatisticsDto, GetStatisticsDto>().ReverseMap();
            CreateMap<Statistics, GetCategoryDtoWithTickets>();
            CreateMap<AddStatisticsDto, GetCategoryDtoWithTickets>();


       

            CreateMap<Ticket, GetTicketDto>();
            CreateMap<ListTicketMatchDto, TicketMatch>();

           
            CreateMap<AddStatisticsDto, Statistics>();
            CreateMap<AddTicketDto, Ticket>();
            CreateMap<AddTicketMatchDto, TicketMatch>();


            CreateMap<Ticket, GetTicketDto>();
            CreateMap<Category, GetCategoryDtoWithTickets>()
                .ForMember(dest => dest.Tickets, opt => opt.MapFrom(src => src.Tickets));
            CreateMap<Statistics, GetStatisticsDto>()
    .ForMember(dest => dest.CategoryDto, opt => opt.MapFrom(src => src.Category));
   

        }
    }
}
