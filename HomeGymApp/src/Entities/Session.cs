using HomeGymApp.src.Entities;
using System.Diagnostics.CodeAnalysis;

namespace HomeGymApp.src.Models
{
    /// <summary>
    /// The main session entity.
    /// </summary>
    public class Session
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="person">The person recording the session.</param>
        /// <param name="timeEntered">The time the session started.</param>
        protected Session(Person person, DateTime timeEntered) 
        {
            Person = person;
            TimeEntered = timeEntered;
            Exercises = new List<Exercise>();
        }

        /// <summary>
        /// The Id of the session.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The person recording the session.
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// The date time the session started.
        /// </summary>
        public DateTime TimeEntered { get; set; }

        /// <summary>
        /// The date time the session ended.
        /// </summary>
        public DateTime TimeLeft { get; set; }

        /// <summary>
        /// Time spent in gym.
        /// </summary>
        public TimeSpan TimeInGym { get; set; }

        /// <summary>
        /// The time the session was last updated.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// List of exercises the user recorded.
        /// </summary>
        public List<Exercise> Exercises { get; set; }

        public static Session Start(Person user)
        {
            Session session = new Session(user, DateTime.Now);
            return session;
        }

        public void End(List<Exercise> exercises)
        {
            Exercises = exercises;
            TimeLeft = DateTime.Now;
            TimeInGym = CalculateTimeInGym(TimeEntered, TimeLeft);
            Person.AddSession();
        }

        private static TimeSpan CalculateTimeInGym([NotNull] DateTime timeEntered, [NotNull] DateTime timeLeft)
        {
            return timeLeft.Subtract(timeEntered);
        }
    }
}