using Microsoft.Learning.UserProfile.Schema.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Learning.UserProfile.Schema
{
    public class PersonDetails
    {
        public FTEDetails FTEDetails;
        public ICollection<PersonRoles> Roles;
        public MCTDetails MCTDetails;
    }
}
