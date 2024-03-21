using System.Security.Cryptography;
using System.Xml.Linq;

namespace DocumentManagementSystemAPI
{
    public enum DocumentMetaDataFormat
    {
        JSON,
        XML,
        CSV
    }

    public abstract class Document
    {
        private readonly int id;
        private readonly string name;
        private readonly string description;

        private Document leftDoc;
        private Document rightDoc;

        protected Document(int id)
        {
            if (IsDocIdValid(id))
            {
                //Web service method call that retrieves document metadata goes here
                this.id = id;
                name = $"Doc{id}";
                description = $"Document description for document: {id}";

            }
            else
            {
                throw new Exception("Invalid Id");
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
        }

        public Document LeftDoc
        {
            get
            {
                return leftDoc;
            }
            set
            {
                leftDoc = value;
            }
        }
        public Document RightDoc
        {
            get
            {
                return rightDoc;
            }
            set
            {
                rightDoc = value;
            }
        }

        private bool IsValidId(int id)
        {
            if (!this.IsDocIdValid(id))
            {
                return false;
            }
            return true;
        }

        public virtual string GetSerializedDocumentMetadata(DocumentMetaDataFormat documentMetaDataFormat)
        {
            string result = null;

            switch (documentMetaDataFormat)
            {
                case DocumentMetaDataFormat.JSON:
                    throw new NotImplementedException();
                case DocumentMetaDataFormat.XML:
                    throw new NotImplementedException();
                case DocumentMetaDataFormat.CSV:
                    result = $"{Id},\"{Name}\",\"{Description}\"";
                    break;
                default:
                    throw new Exception("Invalid document metadata format");
            }
            return result;
        }

        public abstract bool IsDocIdValid(int id);
    }
}