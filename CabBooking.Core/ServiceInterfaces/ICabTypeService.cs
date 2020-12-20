using CabBooking.Core.Entities;
using CabBooking.Core.Models.Reqpest;
using CabBooking.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Core.ServiceInterfaces
{
    public interface ICabTypeService
    {
        Task<IEnumerable<CabType>> GetAllCabType();
        Task<CabType> CreateCabType(CabTypeCreateRequest cabTypeCreateRequest);
        Task<CabType> UpdateCabType(CabType cabType);
        Task<bool> DeleteCabType(int cabTypeId);
        Task<CabTypeDetailResponse> GetCabTypesById(int cabTypeId);
    }
}
