using DatingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BLL.Interface
{
    public interface IValueService
    {        
        Task<IEnumerable<Value>> GetAllValue();
        Task<Value> GetValue(int id);
    }
}
