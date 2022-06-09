using AutoMapper;
using Domain;
using Domain.Entities;
using IncidentApi.Models;
using IncidentApi.Repository.Contracts;
using IncidentApi.WrapperRepository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;       
        private readonly IWrapperRepo _wrapperRepo;
       
        public ContactController(IMapper mapper, IWrapperRepo wrapperRepo)
        {
            _mapper = mapper;
            _wrapperRepo = wrapperRepo;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ItemContactModel>> CreateContact(CreateContactModel create)
        {

            var contactModel = _mapper.Map<Contact>(create);
             _wrapperRepo.Contact.Create(contactModel);
            _wrapperRepo.Save();
            var readcontactModel = _mapper.Map<ItemContactModel>(contactModel);
            return Ok(readcontactModel);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemContactModel>>> GetAllContacts()
        {            
            var contacts = _wrapperRepo.Contact.GetAll();
            var listContacts = _mapper.Map<IEnumerable<ItemContactModel>>(contacts);
            return Ok(listContacts);
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<ActionResult<ItemContactModel>> SearchByEmail(string email)
        {
            var contact =  _wrapperRepo.Contact.GetByEmail(email);

            if (contact == null)
            {
                return NotFound();
            }
            var findItemContact = _mapper.Map<ItemContactModel>(contact);

            return Ok(findItemContact);
        }
       
    }
}
