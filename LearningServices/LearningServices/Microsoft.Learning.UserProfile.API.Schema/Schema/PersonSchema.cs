using Microsoft.Learning.Core.DocumentDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Learning.UserProfile.Schema
{
    public class Person : BaseEntity
    {
        public override string GetCollectionId() => "persons";
        public override string GetDatabaseId() => "user";

        public string FirstName;
        public string LastName;
        public string Email;

        public PersonDetails Details;

        public string MCTId;
    }
}
