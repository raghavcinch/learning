using Microsoft.Azure.Documents;
using Microsoft.Learning.Core.DocumentDB;
using Microsoft.Learning.UserProfile.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Learning.UserProfile.Repository
{
    public class PersonRepository : DocumentDBRepository<Person>
    {
        public PersonRepository(IDocumentClient client) : base(client)
        {
        }
    }
}
