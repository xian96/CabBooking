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
        private readonly ICabTypeRepository _cabTypeRepository;

        public CabTypeService(ICabTypeRepository cabTypeRepository)
        {
            _cabTypeRepository = cabTypeRepository;
        }

        public async Task<IEnumerable<CabType>> GetAllCabType()
        {
            return await _cabTypeRepository.ListAllAsync();
        }

        public async Task<CabType> CreateCabType(CabTypeCreateRequest cabTypeCreateRequest)
        {
            var exists = await _cabTypeRepository.GetExistsAsync(c => c.CabTypeName.Equals(cabTypeCreateRequest.CabTypeName));

            if (exists)
            {
                throw new Exception("Movie Already Exits");
            }

            var cabType = new CabType
            {
                CabTypeId = cabTypeCreateRequest.CabTypeId,
                CabTypeName = cabTypeCreateRequest.CabTypeName
            };

            var createdMovie = await _cabTypeRepository.AddAsync(cabType);

            // response model not used here, cause only two prop
            return cabType;
        }

        public async Task<CabType> UpdateCabType(CabType cabType)
        {

            var updatedMovie = await _cabTypeRepository.UpdateAsync(cabType);

            // response model not used here, cause only two prop
            return updatedMovie;
        }


        public async Task<bool> DeleteCabType(int cabTypeId)
        {
            var cabType = await _cabTypeRepository.GetByIdAsync(cabTypeId);

            if (cabType == null)
            {
                throw new Exception("CabType Not Found");
            }
            //TODO: try catch not added yet
            await _cabTypeRepository.DeleteAsync(cabType);

            //Question: What should i do if the booking have this cabType?

            return true;
        }
    }
}
