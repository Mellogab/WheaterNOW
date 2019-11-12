using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WheaterAPI.Repository
{
    public interface IRepository
    {
        void Add();
        void Remove();
        void Update();
        IEnumerable<object> GetAll();
        object GetItemById();
    }
}
