using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Learning.Core.DocumentDB
{
    public interface IDataRepository
    {

    }

    public interface IDataRepository<T> : IDataRepository
    {
        IOrderedQueryable<T> GetAll();
        T Get(string id);
    }
   
}
