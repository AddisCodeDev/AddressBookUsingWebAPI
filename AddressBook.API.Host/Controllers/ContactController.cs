using AddressBook.API.DataInterface;
using AddressBook.API.DataModel.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AddressBook.API.Host.Controllers
{
    public class ContactController : ApiController
    {
        IContactRepository ContactRepository { get; set; }
        public ContactController(IContactRepository contactRepository)
        {
            ContactRepository = contactRepository;
        }
        // GET: api/Contact
        public ContactsResponseDTO Get()
        {
            return ContactRepository.GetContacts(new ContactsDTO());
        }

        // GET: api/Contact/5
        public ContactDetailResponseDTO Get(Guid id)
        {
            ContactDetailDTO contactDTO = new ContactDetailDTO { Id = id };
            return ContactRepository.GetDetail(contactDTO);
        }

        // POST: api/Contact
        public ContactResponseDTO Post([FromBody]ContactDTO request)
        {
            return ContactRepository.Save(request);
        }

        // PUT: api/Contact/5
        public ContactResponseDTO Put([FromBody]ContactDTO value)
        {
            return ContactRepository.Update(value);
        }

        // DELETE: api/Contact/5
        public ContactResponseDTO Delete(Guid id)
        {
            return ContactRepository.Delete(new ContactDTO { Id = id});
        }
    }
}
