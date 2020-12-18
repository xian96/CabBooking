using CabBooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Core.ServiceInterfaces
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> GetAllPlaces();
        Task<Place> CreatePlace(Place place);
        Task<Place> UpdatePlace(Place place);
        Task<bool> DeletePlace(int placeId);
    }
}
