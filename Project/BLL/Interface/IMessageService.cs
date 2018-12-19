using DatingApp.BLL.Helper;
using DatingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BLL.Interface
{
    public interface IMessageService
    {
        Task<Message> GetMessage(int id);
        Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId);
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        Task<int> SaveChangesAsync();
    }
}
