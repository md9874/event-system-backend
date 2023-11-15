using Application.DTO.MessageDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [SwaggerOperation(Summary = "Retrieves all messages")]
        [HttpGet("{conversationId}")]
        public IActionResult Get(int conversationId)
        {
            var messages = _messageService.GetConversationMessages(conversationId);
            return Ok(messages);
        }

        [SwaggerOperation(Summary = "Create a new message")]
        [HttpPost]
        public IActionResult Create(CreateMessageDTO newMessage)
        {
            var message = _messageService.AddNewMessage(newMessage);
            return Created($"api/message/{message.Id}", message);
        }
    }
}
