using CabBooking.Core.Entities;
using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Infrastructure.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IAsyncRepository<Place> _placeRepository;

        public PlaceService(IAsyncRepository<Place> placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<Place> CreatePlace(Place place)
        {
            var exists = await _placeRepository.GetExistsAsync(p => p.PlaceName.Equals(place.PlaceName));

            if (exists)
            {
                throw new Exception("Place Already Exits");
            }

            var createdMovie = await _placeRepository.AddAsync(place);

            // response model not used here, cause only two prop
            return place;
        }

        public async Task<bool> DeletePlace(int placeId)
        {
            var place = await _placeRepository.GetByIdAsync(placeId);

            if (place == null)
            {
                throw new Exception("place Not Found");
            }
            //TODO: try catch not added yet
            await _placeRepository.DeleteAsync(place);

            //Question: What should i do if the booking have this cabType?

            return true;
        }

        public async Task<IEnumerable<Place>> GetAllPlaces()
        {
            return await _placeRepository.ListAllAsync();
        }

        public async Task<Place> UpdatePlace(Place place)
        {
            var exists = await _placeRepository.GetExistsAsync(p => p.PlaceName.Equals(place.PlaceName));

            if (!exists)
            {
                throw new Exception("Place not Found");
            }

            var updatedPlace = await _placeRepository.UpdateAsync(place);

            // response model not used here, cause only two prop
            return updatedPlace;
        }
    }
}
