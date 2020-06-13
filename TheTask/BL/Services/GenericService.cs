using AutoMapper;
using BL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class GenericService<BLModel, TEntity> : IGenericService<BLModel> 
        where BLModel: class
        where TEntity: class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<BLModel> Get()
        {
            var data = _repository.Get();
            var modelsBL = _mapper.Map<IEnumerable<BLModel>>(data);

            return modelsBL;
        }

        public BLModel FindById(int id)
        {
            var data = _repository.FindById(id);
            var modelBL = _mapper.Map<BLModel>(data);
            return modelBL;
        }
    }
}
