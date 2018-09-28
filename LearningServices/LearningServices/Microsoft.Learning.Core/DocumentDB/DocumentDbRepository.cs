using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Learning.Core.DocumentDB
{
    public class DocumentDBRepository<T> : IDataRepository<T> where T : BaseEntity, new()
    {
        private Uri _collectionUri;
        private IDocumentClient _client;
        protected static readonly FeedOptions DefaultFeedOptions = new FeedOptions { EnableCrossPartitionQuery = true };

        
        public DocumentDBRepository(IDocumentClient client)
        {
            var fakeInstance = new T();
            _collectionUri = UriFactory.CreateDocumentCollectionUri(fakeInstance.GetDatabaseId(), fakeInstance.GetCollectionId());
            _client = client;
        }

        public IOrderedQueryable<T> Items => this.GetAll();
        public IOrderedQueryable<T> GetAll() => _client.CreateDocumentQuery<T>(_collectionUri, DefaultFeedOptions);
        public T Get(string id) => _client.CreateDocumentQuery<T>(_collectionUri, DefaultFeedOptions).Where(a => a.id == id).SingleOrDefault();
    }
}
