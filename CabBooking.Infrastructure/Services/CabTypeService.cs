using CabBooking.Core.Entities;
using CabBooking.Core.Models.Reqpest;
using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Infrastructure.Services
{
    public class CabTypeService : ICabTypeService
    {
        private readonly IAsyncRepository<CabType> _cabTypeRepository;

        public CabTypeService(IAsyncRepository<CabType> cabTypeRepository)
        {
            _cabTypeRepository = cabTypeRepository;
        }

        public async Task<IEnumerable<CabType>> GetAllCabType()
        {
            return await _cabTypeRepository.ListAllAsync();
        }

        public async Task<CabType> CreateCabType(CabTypeCreateRequest cabTypeCreateRequest)
        {
            var cabType = new CabType
            {
                CabTypeId = cabTypeCreateRequest.CabTypeId,
                CabTypeName = cabTypeCreateRequest.CabTypeName
            };

            var createdMovie = await _cabTypeRepository.AddAsync(cabType);

            // response model not used here, cause only two prop
            return cabType;
        }
    }
}
