using DatingApp.BLL.Interface;
using DatingApp.Data;
using DatingApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.BLL.Implementation
{
    public class ValueService : BaseDataService, IValueService
    {
        public ValueService(IDatingAppData repo):base(repo)
        {  
        }

        public async Task<IEnumerable<Value>> GetAllValue()
        {
            return await _value.GetAllAsync();
        }    
        
        public async Task<Value> GetValue(int id)
        {
            return await _value.GetSingleAsync(x => x.Id == id);
        }
    }
}
