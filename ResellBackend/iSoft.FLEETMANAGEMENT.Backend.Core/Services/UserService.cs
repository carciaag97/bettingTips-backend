using AutoMapper;
using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Core.Handlers;
using iSoft.FLEETMANAGEMENT.Backend.Core.UnitOfWork;
using iSoft.FLEETMANAGEMENT.Backend.Infrastructure.Exceptions;
using ResellBackendCore.Database.Dtos.UserDto;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Services
{
    public class UserService
    {
        public EfUnitOfWork _efUnitOfWork { get; set; }
        public ResellDbContext _resellDbContext { get; set; }
        private readonly IMapper _mapper;
        public AuthTokenHandler _authTokenHandler { get; set; }


        public UserService(EfUnitOfWork efUnitOfWork, ResellDbContext resellDbContext, IMapper mapper,AuthTokenHandler authToken)
        {
            _efUnitOfWork = efUnitOfWork;
            _resellDbContext = resellDbContext;
            _mapper = mapper;
            _authTokenHandler = authToken;
        }


        public async Task<GetUserDto> AddUser(AddUserDto newUser)
        {
            var user = _mapper.Map<User>(newUser);
            _efUnitOfWork._userRepository.Add(user);
            await _efUnitOfWork.SaveAsync();
            var dto = _mapper.Map<GetUserDto>(user);
            dto.Token = _authTokenHandler.GenerateTokenAsync(user);
            return dto;
        }

        public async Task<GetUserDtoWithDetails> GetUserDtoByIdAsync(int userId)
        {
            var user = await _efUnitOfWork._userRepository.GetUserByIdAsync(userId);
            if (user == null)
                throw new WrongInputException($"Utilizatorul cu id={userId} nu exista");

            var userWithDetails = new GetUserDtoWithDetails()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                FullName = user.FullName,
                Role = user.Role,
                Tickets = user.Tickets,
                News = user.News

            };
            return userWithDetails;
        }
         
        public async Task DeleteUserAsync(int userId)
        {
            var user = _efUnitOfWork._userRepository.GetById(userId);
            if (user == null)
                throw new WrongInputException($"User with id={userId} does not exist.");

            if (user.IsDeleted)
                throw new WrongInputException($"User with id={userId} is already deleted.");

            user.IsDeleted = true;
            await _efUnitOfWork.SaveAsync();
        }

    }
}
