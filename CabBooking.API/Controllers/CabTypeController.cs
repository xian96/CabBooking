using CabBooking.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabTypeController : ControllerBase
    {
        private readonly ICabTypeService _cabTypeService;
        public CabTypeController(ICabTypeService cabTypeService)
        {
            _cabTypeService = cabTypeService;
        }

        //should be Add/Update/Delete/List the cab/s.
        [HttpGet]
        public async Task<IActionResult> GetAllCabTypes()
        {
            var cabTypes = await _cabTypeService.GetAllCabType();
            if (cabTypes == null)
            {
                return NotFound("no CabTypes Found");
            }
            return Ok(cabTypes);
        }

        [HttpGet]
        [Route("{cabTypeId:int}")]
        public async Task<IActionResult> GetCabTypesById(int cabTypeId)
        {
            var cabTypes = await _cabTypeService.GetCabTypesById(cabTypeId);
            if (cabTypes == null)
            {
                return NotFound("no CabTypes Found");
            }
            return Ok(cabTypes);
        }


    }
}
