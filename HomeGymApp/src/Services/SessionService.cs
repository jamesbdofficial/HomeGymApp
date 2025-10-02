using HomeGymApp.src.Entities;
using HomeGymApp.src.Repositories;

namespace HomeGymApp.src.Services
{
    /// <summary>
    /// Service class for sessions.
    /// </summary>
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IPersonRepository personRepository;

        public SessionService(ISessionRepository sessionRepository, IPersonRepository personRepository) 
        {
            this.sessionRepository = sessionRepository;
            this.personRepository = personRepository;
        }

        /// <summary>
        /// Method to create a Session.
        /// </summary>
        /// <returns></returns>
        public async Task<Session?> Create(Guid personId)
        {
            Person? person = await personRepository.GetByIdAsync(personId);

            if (person == null)
            {
                //ToDo: Throw Errors
                return null;
            }

            Session newSession = Session.Start(person);

            await sessionRepository.AddAsync(newSession);
            await sessionRepository.SaveChangesAsync();

            return newSession;
        }

        public async Task<Session?> End(Guid personId)
        {
            Person? person = await personRepository.GetByIdAsync(personId);

            if (person == null)
            {
                //ToDo: Throw Errors
                return null;
            }

            Session? currentSession = await sessionRepository.GetActiveSessionForPersonAsync(personId);

            if (currentSession == null)
            {
                //ToDo: Throw Errors
                return null;
            }

            currentSession.End();

            await sessionRepository.UpdateAsync(currentSession);
            await sessionRepository.SaveChangesAsync();

            person.AddSession(currentSession);
            await personRepository.UpdateAsync(person);
            await sessionRepository.SaveChangesAsync();

            return currentSession;
        }

        public async void RecordExercise(Guid personId, Exercise exercise)
        {
            Person? person = await personRepository.GetByIdAsync(personId);

            if (person == null)
            {
                //ToDo: Throw Errors
                return;
            }

            Session? activeSession = await sessionRepository.GetActiveSessionForPersonAsync(personId);

            if (activeSession == null)
            {
                //ToDo: Throw Errors
                return;
            }

            activeSession.AddExercise(exercise);

            await sessionRepository.UpdateAsync(activeSession);
            await sessionRepository.SaveChangesAsync();
        }
    }
}