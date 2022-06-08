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
        public async Task<ActionResult<ItemAccountModel>> CreateAccount (CreateAccountModel create,string email)
        {
            
                var res = _wrapperRepo.Contact.GetByEmail(email);
                if(res == null)
                {
                    return BadRequest();
                }
               
           
           
            var contactModel = _mapper.Map<Account>(create);

           // var r = _wrapperRepo.Account.CreateAccount(res, contactModel);                 
            
           
            //var readcontactModel = _mapper.Map<ItemAccountModel>(contactModel);
            return Ok();
        }
    }
}
