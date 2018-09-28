using Microsoft.Learning.Core.DocumentDB;
using Microsoft.Learning.UserProfile.API.Shared;
using Microsoft.Learning.UserProfile.Schema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Learning.UserProfile.Manager
{
    public class PersonManager : IPersonManager
    {
        const int RoleValues_MCT = 1;
        private IDataRepository<Person> _personRepository;
        public PersonManager(IDataRepository repository)
        {
            _personRepository = repository as IDataRepository<Person>;
        }

        public IQueryable<FullTimeEmployeeContract> GetAllFullTimeEmployees()
        {
            var fteDetails = _personRepository.GetAll().Where(a => a.Details.FTEDetails != null).Select(a => new FullTimeEmployeeContract
            {
                Alias = a.Details.FTEDetails.Alias,
                Email = a.Email
            });
            return fteDetails;
        }
        public IQueryable<MCTContract> GetMCTs()
        {
            
            var mctDetails = _personRepository.GetAll().Where(a => a.Details.Roles.Any(role => role.Id == RoleValues_MCT)).Select(a => new MCTContract
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                MCTId = a.Details.MCTDetails.MCTId,
            });
            return mctDetails;
        }
        public IQueryable<PersonContract> GetAllPeople()
        {

            var mctDetails = _personRepository.GetAll().Select(a => new PersonContract
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                PUID = a.id
            });
            return mctDetails;
        }

        public PersonContract Get(string Id)
        {
            var person = _personRepository.Get(Id);
            return new PersonContract
            {
                FirstName = person.FirstName,
                PUID = person.id,
                LastName = person.LastName
            };
        }
    }
}
