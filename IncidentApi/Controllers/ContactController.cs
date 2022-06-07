using AutoMapper;
using Domain;
using Domain.Entities;
using IncidentApi.Models;
using IncidentApi.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;
      
        public ContactController(IMapper mapper,IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
           
        }
        [HttpPost]
        public async Task<ActionResult<ItemContactModel>> CreateContact(CreateContactModel create)
        {
            
            var contactModel = _mapper.Map<Contact>(create);
            await _contactRepository.Create(contactModel);
            await _contactRepository.Save();           
            var readcontactModel = _mapper.Map<ItemContactModel>(contactModel);           
            return Ok(readcontactModel);
        }
    }
}
