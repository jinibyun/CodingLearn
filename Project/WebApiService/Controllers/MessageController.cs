using AutoMapper;
using DatingApp.BLL;
using DatingApp.BLL.Helper;
using DatingApp.BLL.Interface;
using DatingApp.WebApiService.Dto;
using DatingApp.WebApiService.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DatingApp.WebApiService.Controllers
{
    [RoutePrefix("api/Message")]
    [JwtAuthentication]
    [Route("api/users/{userId}/[controller]")]
    public class MessageController : BaseApiController
    {
        private readonly IMessageService MessageService;
        private readonly IUserService UserService;
        public MessageController(IDataService _service) : base(_service)
        {
            MessageService = Service.MessageService;
            UserService = Service.UserService;
        }

        [HttpGet]
        [Route("{id}", Name = "GetMessage")]
        public async Task<IHttpActionResult> GetMessage(int userId, int id)
        {
            var messageFromRepo = await MessageService.GetMessage(id);

            if (messageFromRepo == null)
                return NotFound();

            return Ok(messageFromRepo);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetMessagesForUser(int userId,
            [FromUri]MessageParams messageParams)
        {
            messageParams.UserId = userId;

            var messagesFromRepo = await MessageService.GetMessagesForUser(messageParams);

            var messages = Mapper.Map<IEnumerable<MessageToReturnDto>>(messagesFromRepo);

            HttpContext.Current.Response.AddPagination(messagesFromRepo.CurrentPage, messagesFromRepo.PageSize,
                messagesFromRepo.TotalCount, messagesFromRepo.TotalPages);

            return Ok(messages);
        }

        [HttpGet]
        [Route("thread/{recipientId}")]
        public async Task<IHttpActionResult> GetMessageThread(int userId, int recipientId)
        {            
            var messagesFromRepo = await MessageService.GetMessageThread(userId, recipientId);

            var messageThread = Mapper.Map<IEnumerable<MessageToReturnDto>>(messagesFromRepo);

            return Ok(messageThread);
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateMessage(int userId, MessageForCreationDto messageForCreationDto)
        {
            var sender = await UserService.GetUserById(userId);

            messageForCreationDto.SenderId = userId;

            var recipient = await UserService.GetUserById(messageForCreationDto.RecipientId);

            if (recipient == null)
                return BadRequest("Could not find user");

            var message = Mapper.Map<DatingApp.Data.Message>(messageForCreationDto);

            MessageService.AddMessage(message);

            if (await MessageService.SaveChangesAsync() > 0)
            {
                var messageToReturn = Mapper.Map<MessageToReturnDto>(message);
                return CreatedAtRoute("GetMessage", new { id = message.Id }, messageToReturn);
            }

            throw new Exception("Creating the message failed on save");
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IHttpActionResult> DeleteMessage(int id, int userId)
        {           
            var messageFromRepo = await MessageService.GetMessage(id);

            if (messageFromRepo.SenderId == userId)
                messageFromRepo.SenderDeleted = true;

            if (messageFromRepo.RecipientId == userId)
                messageFromRepo.RecipientDeleted = true;

            if (messageFromRepo.SenderDeleted && messageFromRepo.RecipientDeleted)
                MessageService.DeleteMessage(messageFromRepo);

            if (await MessageService.SaveChangesAsync() > 0)
                return Content(HttpStatusCode.NoContent, "successfully deleted");

            throw new Exception("Error deleting the message");
        }

        [HttpPost]
        [Route("{id}/read")]
        public async Task<IHttpActionResult> MarkMessageAsRead(int userId, int id)
        {
            var message = await MessageService.GetMessage(id);

            if (message.RecipientId != userId)
                return Unauthorized();

            message.IsRead = true;
            message.DateRead = DateTime.Now;

            await MessageService.SaveChangesAsync();

            return Content(HttpStatusCode.NoContent, "successfully marked");
        }
    }
}
