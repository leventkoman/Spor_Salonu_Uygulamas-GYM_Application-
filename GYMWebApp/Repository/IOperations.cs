using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMWebApp.Repository
{
   public interface IOperations<T>
    {
        bool DeleteIt(T model);
        T Create(T model);
        IList<T> ListtAll();
    }
}
