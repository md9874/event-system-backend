using Application.DTO.ConversationDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationService _conversationService;

        public ConversationController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }
        [SwaggerOperation(Summary = "Retrieves all conversation conversation")]
        [HttpGet]
        public IActionResult Get()
        {
            var conversations = _conversationService.GetAllUserConversations();
            return Ok(conversations);
        }

        [SwaggerOperation(Summary = "Retrieves a specific conversation conversation by unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var conversation = _conversationService.GetUserConversation(id);
            if (conversation == null)
            {
                return NotFound();
            }
            return Ok(conversation);
        }

        [SwaggerOperation(Summary = "Create a new conversation conversation")]
        [HttpPost]
        public IActionResult Create(CreateConversationDTO newConversation)
        {
            var conversation = _conversationService.AddNewUserConversation(newConversation);
            return Created($"api/conversation/{conversation.Id}", conversation);
        }

        [SwaggerOperation(Summary = "ChangePassword a existing conversation")]
        [HttpPut]
        public IActionResult Update(UpdateConversationDTO updatedConversation)
        {
            _conversationService.ChangeUserConversationTitle(updatedConversation);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific conversation")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _conversationService.DeleteUserConversation(id);
            return NoContent();
        }
    }
}
