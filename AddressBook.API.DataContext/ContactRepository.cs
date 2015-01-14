using AddressBook.API.DataInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.API.DataModel.Operations;
using ServiceStack.OrmLite;
using System.Data;
using AddressBook.API.DataModel.Types;
using System.Configuration;
using AutoMapper;

namespace AddressBook.API.DataContext
{
    public class ContactRepository : IContactRepository
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public IDbConnection DbConnection { get; set; }

        public ContactRepository()
        {
            var db = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(), PostgreSqlDialect.Provider);
            using (var dbcon = db.OpenDbConnection())
            {
                dbcon.CreateTable<Contact>();
            }
            DbConnectionFactory = db;
        }
        public ContactResponseDTO Delete(ContactDTO request)
        {
            ContactResponseDTO response = new ContactResponseDTO();
            Mapper.CreateMap<ContactDTO, Contact>();
            Contact ContactToDelete = Mapper.Map<ContactDTO, Contact>(request);
            using (DbConnection = DbConnectionFactory.OpenDbConnection())
            {
                DbConnection.Delete<Contact>(ContactToDelete);
            }
            return response;
        }

        public ContactsResponseDTO GetContacts(ContactsDTO request)
        {
            ContactsResponseDTO response = new ContactsResponseDTO();
            using (DbConnection = DbConnectionFactory.OpenDbConnection())
            {
                response.Contacts  = DbConnection.Select<Contact>().ToList<Contact>() ;
            }
            return response;
        }

        public ContactDetailResponseDTO GetDetail(ContactDetailDTO request)
        {
            ContactDetailResponseDTO response = new ContactDetailResponseDTO();
            
            using (DbConnection = DbConnectionFactory.OpenDbConnection())
            {
                response.Contact = DbConnection.Select<Contact>().Where(c => c.Id == request.Id).FirstOrDefault() ;
            }
            return response;
        }

        public ContactResponseDTO Save(ContactDTO request)
        {
            ContactResponseDTO response = new ContactResponseDTO();
            Mapper.CreateMap<ContactDTO, Contact>();
            Contact newContact = Mapper.Map<ContactDTO, Contact>(request);
            newContact.Id = Guid.NewGuid();
            using (DbConnection = DbConnectionFactory.OpenDbConnection())
            {
                DbConnection.Insert<Contact>(newContact);
            }
            return response;
        }

        public ContactResponseDTO Update(ContactDTO request)
        {
            ContactResponseDTO response = new ContactResponseDTO();
            Mapper.CreateMap<ContactDTO, Contact>();
            Contact updatedContact = Mapper.Map<ContactDTO, Contact>(request);
            using (DbConnection = DbConnectionFactory.OpenDbConnection())
            {
                DbConnection.Update(updatedContact);
            }
            return response;
        }
    }
}
