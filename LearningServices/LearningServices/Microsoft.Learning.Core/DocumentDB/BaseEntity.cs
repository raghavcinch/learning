using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Learning.Core.DocumentDB
{
    public abstract class BaseEntity 
    {


        public string id;
        public abstract string GetCollectionId();
        public abstract string GetDatabaseId();
    }
}
