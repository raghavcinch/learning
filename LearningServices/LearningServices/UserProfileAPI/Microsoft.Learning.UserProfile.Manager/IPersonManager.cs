using Microsoft.Learning.UserProfile.API.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Learning.UserProfile.Manager
{
    public interface IPersonManager
    {
        IQueryable<FullTimeEmployeeContract> GetAllFullTimeEmployees();
        IQueryable<MCTContract> GetMCTs();
        IQueryable<PersonContract> GetAllPeople();
        PersonContract Get(string Id);
    }
}
