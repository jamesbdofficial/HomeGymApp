using HomeGymApp.src.Constants;
using HomeGymApp.src.Entities;
using HomeGymApp.src.Repositories;

namespace HomeGymApp.src.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<Person> Create()
        {
            // These will be removed when dtos / commands / commandhandlers are added.
            string name = "John Smith";
            string emailAddress = "email@address.com";
            UserType userType = UserType.Visitor;

            Person newPerson = Person.Create(name, emailAddress, userType);

            await personRepository.AddAsync(newPerson);
            await personRepository.SaveChangesAsync();

            return newPerson;
        }

        public async void UpdateEmailAddress(Guid id, string email)
        {
            Person? person = await personRepository.GetByIdAsync(id);

            if (person == null)
            {
                //ToDo: Throw Errors
                return;
            }

            person.UpdateEmailAddress(email);
            
            await personRepository.UpdateAsync(person);
            await personRepository.SaveChangesAsync();
        }

        public async void UpdateUserType(Guid id, UserType userType)
        {
            Person? person = await personRepository.GetByIdAsync(id);

            if (person == null)
            {
                //ToDo: Throw Errors
                return;
            }

            person.UpdateUserType(userType);

            await personRepository.UpdateAsync(person);
            await personRepository.SaveChangesAsync();
        }
    }
}