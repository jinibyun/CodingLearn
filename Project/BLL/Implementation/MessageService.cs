using DatingApp.BLL.Helper;
using DatingApp.BLL.Interface;
using DatingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BLL.Implementation
{
    public class MessageService : BaseDataService, IMessageService
    {
        public MessageService(IDatingAppData repo) : base(repo)
        {

        }        

        public async Task<Message> GetMessage(int id)
        {
            return await _message.GetSingleAsync(m => m.Id == id);
        }

        public async Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams)
        {
            var messages = await _message.GetAllAsync(                                   
                                    sender => sender.User,
                                    sender => sender.User.Photos,
                                    receiver => receiver.User1,
                                    receiver => receiver.User1.Photos

                                    );

            switch (messageParams.MessageContainer)
            {
                case "Inbox":
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId
                        && u.RecipientDeleted == false);
                    break;
                case "Outbox":
                    messages = messages.Where(u => u.SenderId == messageParams.UserId
                        && u.SenderDeleted == false);
                    break;
                default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId
                        && u.RecipientDeleted == false && u.IsRead == false);
                    break;
            }

            messages = messages.OrderByDescending(d => d.MessageSent);

            return PagedList<Message>.CreateAsync(messages.AsQueryable(), messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
        {
            var messages = await _message.GetAllAsync(
                                    m => m.RecipientId == userId && m.RecipientDeleted == false
                                    && m.SenderId == recipientId
                                    || m.RecipientId == recipientId && m.SenderId == userId
                                    && m.SenderDeleted == false,
                                    sender => sender.User,
                                    sender => sender.User.Photos,
                                    receiver => receiver.User1,
                                    receiver => receiver.User1.Photos
                                    
                                    );
            return await Task.FromResult(messages.OrderByDescending(m => m.MessageSent).ToList());
        }

        public void AddMessage(Message message)
        {
            _message.Add(message);
        }

        public async Task<int> SaveChangesAsync()
        {           
            return await _repo.SaveChangesAsync();
        }

        public void DeleteMessage(Message message)
        {
            _message.Remove(message);
        }
    }
}
