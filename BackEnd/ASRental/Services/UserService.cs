﻿using ASRental.Models;
using ASRental.Repository.Interfaces;
using ASRental.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                _userRepository.Create(user);
                await _userRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                var user = await GetUserById(id);
                _userRepository.Delete(user);
                await _userRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<List<User>> GetAllUser()
        {
            try
            {
                return _userRepository.FindAll().OrderBy(user => user.Email).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid id)
        {
            try
            {
                return _userRepository.FindByCondition(user => user.UserId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateUser(Guid id, User user)
        {
            try
            {
                await GetUserById(id);
                _userRepository.Update(user);
                await _userRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool UserExists(Guid id)
        {
            return _userRepository.FindByCondition(e => e.UserId == id).Any();
        }
    }
}
