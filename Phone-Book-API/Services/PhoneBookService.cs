using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PhoneBookAPI.Dto;
using PhoneBookAPI.Models;

namespace PhoneBookAPI.Services
{
    public class PhoneBookService
    {
        private readonly IMongoCollection<PhoneNumber> _phoneBookCollection;

        public PhoneBookService(IOptions<PhoneBookDatabaseSettings> phoneBookDatabaseSettings)
        {
            var mongoClient = new MongoClient(phoneBookDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(phoneBookDatabaseSettings.Value.DatabaseName);
            _phoneBookCollection = mongoDatabase.GetCollection<PhoneNumber>(phoneBookDatabaseSettings.Value.CollectionName);
        }

        public async Task<PhoneNumber> CreatePhoneNumber(CreatePhoneNumberDto createPhoneNumberDto)
        {
            PhoneNumber phoneNumber = new()
            {
                Name = createPhoneNumberDto.Name,
                Number = createPhoneNumberDto.Number
            };

            await _phoneBookCollection.InsertOneAsync(phoneNumber);

            return phoneNumber;
        }

        public async Task<List<PhoneNumber>> GetAllPhoneNumbers() => await _phoneBookCollection.Find(_ => true).ToListAsync();

        public async Task<PhoneNumber> GetPhoneNumberById(string id) => await _phoneBookCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<PhoneNumber> UpdatePhoneNumber(string id, UpdatePhoneNumberDto updatePhoneNumberDto)
        {
            PhoneNumber phoneNumber = new()
            {
                Id = id,
                Name = updatePhoneNumberDto.Name,
                Number = updatePhoneNumberDto.Number
            };

            await _phoneBookCollection.ReplaceOneAsync(x => x.Id == id, phoneNumber);

            return phoneNumber;
        }

        public async Task<PhoneNumber> DeletePhoneNumber(string id)
        {
            var phoneNumber = await _phoneBookCollection.FindOneAndDeleteAsync(x => x.Id == id);

            return phoneNumber;
        }
    }
}
