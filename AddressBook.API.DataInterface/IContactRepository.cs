using AddressBook.API.DataModel.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.API.DataInterface
{
    public interface IContactRepository
    {
        ContactResponseDTO Save(ContactDTO request);
        ContactResponseDTO Update(ContactDTO request);
        ContactResponseDTO Delete(ContactDTO request);
        ContactsResponseDTO GetContacts(ContactsDTO request);
        ContactDetailResponseDTO GetDetail(ContactDetailDTO request);
    }
}
