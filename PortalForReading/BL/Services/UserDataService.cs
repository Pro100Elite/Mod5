using AutoMapper;
using BL.Interfaces;
using BL.Models;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class UserDataService: IUserDataService
    {
        private readonly IUserDataRepository _repository;
        private readonly IMapper _mapper;

        public UserDataService(IUserDataRepository userDataRepository, IMapper mapper)
        {
            _repository = userDataRepository;
            _mapper = mapper;
        }

        public UserDataModel GetById(string accountId, int bookId)
        {
            var userData = _repository.GetById(accountId, bookId);

            var result = _mapper.Map<UserDataModel>(userData);

            return result;
        }

        public void Create(UserDataModel userData)
        {
            var result = _mapper.Map<UserData>(userData);

            _repository.Create(result);
        }

        public void Update(UserDataModel userData)
        {
            var result = _mapper.Map<UserData>(userData);

            _repository.Update(result);
        }
    }
}
