using PhoneBookAPI.Dto;
using PhoneBookAPI.Models;

namespace PhoneBookAPI.Services
{
    public interface IPhoneBookService
    {
        Task<PhoneNumber> CreatePhoneNumber(CreatePhoneNumberDto createPhoneNumberDto);
        Task<PhoneNumber> DeletePhoneNumber(string id);
        Task<List<PhoneNumber>> GetAllPhoneNumbers();
        Task<PhoneNumber> GetPhoneNumberById(string id);
        Task<PhoneNumber> UpdatePhoneNumber(string id, UpdatePhoneNumberDto updatePhoneNumberDto);
    }
}