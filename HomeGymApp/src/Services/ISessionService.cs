using HomeGymApp.src.Entities;

namespace HomeGymApp.src.Services
{
    public interface ISessionService
    {
        Task<Session?> Create(Guid personId);

        Task<Session?> End(Guid personId);

        void RecordExercise(Guid personId, Exercise exercise);
    }
}
