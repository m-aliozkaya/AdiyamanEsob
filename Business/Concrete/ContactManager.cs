using Business.Abstract;
using Core.Utilities.Mails.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class ContactManager : IContactService
{
        private readonly IContactDal _contactDal;
        private readonly IMailService _mailService;

        public ContactManager(IContactDal contactDal, IMailService mailService)
        {
            _contactDal = contactDal;
            _mailService = mailService;
        }

        public async Task<IResult> AddAsync(Contact contact)
        {
            await _contactDal.AddAsync(contact);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var deletedContact = await _contactDal.GetAsync(x => x.Id == id);
            await _contactDal.DeleteAsync(deletedContact);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Contact>>> GetAllAsync()
        {
            var contacts = await _contactDal.GetAllByDateAsync();
            return new SuccessDataResult<List<Contact>>(contacts);
        }

        public async Task<IDataResult<Contact>> GetByIdAsync(int id)
        {
            var contact = await _contactDal.GetAsync(x => x.Id == id);
            return new SuccessDataResult<Contact>(contact);
        }

        public async Task<IResult> SendMailAsync(Contact contact)
        {
            var data = new Dictionary<string, string>()
            {
                { "İsim", contact.Name },
                { "Email", contact.Email },
                { "Telefon", contact.Phone },
                { "Mesaj", contact.Message },
            };
            var mail = new Mail("Adıyaman Esob iletişim formundan mesaj", data, "İletişim Formu");

            return await _mailService.SendAsync(mail);
        }

        public async Task<IResult> UpdateAsync(Contact contact)
        {
            await _contactDal.UpdateAsync(contact);
            return new SuccessResult();
        }
}