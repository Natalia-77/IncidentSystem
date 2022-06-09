
using AutoMapper;
using Domain.Entities;
using IncidentApi.Models;
using IncidentApi.WrapperRepository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWrapperRepo _wrapperRepo;

        public IncidentController(IMapper mapper, IWrapperRepo wrapperRepo)
        {
            _mapper = mapper;
            _wrapperRepo = wrapperRepo;
        }

        [HttpPost]
        [Route("addIncident")]
        public async Task<ActionResult<ItemIncidentModel>> CreateIncident([FromBody] CreateIncidentModel create)
        {           
            
                var checkName = _wrapperRepo.Account.GetByName(create.AccountAddModels.Name);

                if (checkName == null)
                {
                    return NotFound(new { message = "There is no account such name." });
                }
            

            var newItem = new Incident();
            newItem.Description = create.Description;
            newItem.Name = create.Name;
            _wrapperRepo.Incident.CreateIncident(newItem);
            _wrapperRepo.Save();

            if (checkName.IncidentNameKey == null)
            {
                checkName.Incident = newItem;
                _wrapperRepo.Save();
            }

            var res = _mapper.Map<ItemIncidentModel>(newItem);
            return Ok(res.Name);
        }
    }
}
