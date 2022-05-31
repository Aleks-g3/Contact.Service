using AutoMapper;
using Contact.Service.API.Entities;
using Contact.Service.Core.Models;
using Contact.Service.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;
        private readonly IMapper mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            this.mapper = mapper;
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllAsync([FromServices] IContactRepository contactRepository)
        {
            var contacts = await contactRepository.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetByIdAsync([FromServices] IContactRepository contactRepository, [FromRoute] int userId)
        {
            var contact = await contactRepository.GetByIdAsync(userId);
            return Ok(contact);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int userId, [FromBody] ContactDTO contactDTO)
        {
            var contact = mapper.Map<ContactEntity>(contactDTO);
            await contactService.UpdateAsync(userId, contact);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] ContactDTO contactDTO)
        {
            var contact = mapper.Map<ContactEntity>(contactDTO);
            var contactId = await contactService.AddAsync(contact);
            return Ok(contactId);
        }
    }
}
