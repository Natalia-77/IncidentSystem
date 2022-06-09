using AutoMapper;
using Domain.Entities;
using IncidentApi.Models;
using IncidentApi.WrapperRepository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IncidentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWrapperRepo _wrapperRepo;

        public AccountController(IMapper mapper, IWrapperRepo wrapperRepo)
        {
            _mapper = mapper;
            _wrapperRepo = wrapperRepo;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ItemAccountModel>> CreateAccount([FromBody] CreateAccountModel create, string? first, string? second)
        {
            foreach (var item in create.Contacts)
            {
                var checkEmail = _wrapperRepo.Contact.GetByEmail(item.Email);

                if (!string.IsNullOrEmpty(first) && !string.IsNullOrEmpty(second))
                {
                    var newContact = new Contact();
                    newContact.FirstName = first;
                    newContact.LastName = second;
                    newContact.Email = item.Email;
                    newContact.AccountId = null;
                    _wrapperRepo.Contact.Create(newContact);
                    _wrapperRepo.Save();
                }
                else if (checkEmail == null)
                {

                    return NotFound(new { message = "There is no contact such email.Create new contact." });
                }
            }
           
            var newItem = new Account();
            newItem.Name = create.Name;
            _wrapperRepo.Account.CreateAccount(newItem);
            _wrapperRepo.Save();

          
            foreach (var item in create.Contacts)
            {
                var contactUpdate = _wrapperRepo.Contact.GetByEmail(item.Email);
                if (contactUpdate.AccountId == null)
                {
                    contactUpdate.Account = newItem;
                    _wrapperRepo.Save();
                }
            }

            return Ok(newItem.Name);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemAccountModel>>> GetAllAccount()
        {
            var contacts = _wrapperRepo.Account.GetAllAccounts();
            //var listContacts = _mapper.Map<IEnumerable<ItemAccountModel>>(contacts);
            return Ok(contacts);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<ItemAccountModel>> SearchByEmail(string name)
        {
            var contact = _wrapperRepo.Account.GetByName(name);

            if (contact == null)
            {
                return NotFound();
            }
            var findItemContact = _mapper.Map<ItemAccountModel>(contact);

            return Ok(findItemContact);
        }
    }
}
