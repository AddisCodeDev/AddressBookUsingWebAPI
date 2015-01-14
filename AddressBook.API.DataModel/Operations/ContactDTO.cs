using AddressBook.API.DataModel.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.API.DataModel.Operations
{
    //[Api("Creates/Updates a Contact")]
    //[Route("/Contact", "Post, Delete, PATCH, Put, Options")]
    public class ContactDTO : Contact//, IReturn<ContactResponseDTO>
    {
    }
    public class ContactResponseDTO// : IHasResponseStatus
    {
        public ResponseStatus ResponseStatus
        { get; set; }

        public ContactResponseDTO()
        {
            this.ResponseStatus = new ResponseStatus();
        }
    }
    //[Api("Gets all contacts in the address book")]
    //[Route("/Contact", "Get,Options")]
    public class ContactsDTO //: IReturn<ContactsResponseDTO>
    {
    }
    public class ContactsResponseDTO// : IHasResponseStatus
    {
        public ResponseStatus ResponseStatus{ get; set; }
        public List<Contact> Contacts { get; set; }
        public ContactsResponseDTO()
        {
            this.ResponseStatus = new ResponseStatus();
            this.Contacts = new List<Contact>();
        }
    }
    //[Api("Gets Detailed Contact")]
    //[Route("/Contact/{Id}","Get, Options")]
    public class ContactDetailDTO// : IReturn<ContactDetailResponseDTO>
    {
        public Guid Id { get; set; }
    }
    public class ContactDetailResponseDTO// : IHasResponseStatus
    {
        public ResponseStatus ResponseStatus { get; set; }
        public Contact Contact { get; set; }
        public ContactDetailResponseDTO()
        {
            this.Contact = new Contact();
            this.ResponseStatus = new ResponseStatus();
        }
    }
}
