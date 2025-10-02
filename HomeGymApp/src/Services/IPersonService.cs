using HomeGymApp.src.Constants;
using HomeGymApp.src.Entities;

namespace HomeGymApp.src.Services
{
    public interface IPersonService
    {
        Task<Person> Create();

        void UpdateEmailAddress(Guid id, string email);

        void UpdateUserType(Guid id, UserType userType);
    }
}