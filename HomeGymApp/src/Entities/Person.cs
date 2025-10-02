using HomeGymApp.src.Constants;

namespace HomeGymApp.src.Entities
{
    /// <summary>
    /// The main person entity.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the person.</param>
        /// <param name="emailAddress">The email address of the person.</param>
        /// <param name="userType">The user type.</param>
        protected Person(string name, string emailAddress, UserType userType) 
        {
            Id = Guid.NewGuid();
            Name = name;
            EmailAddress = emailAddress;
            Sessions = new List<Session>();
            LastUpdated = DateTime.Now;
            UserType = userType;
        }

        public static Person Create(string name, string emailAddress, UserType userType)
        {
            return new Person(name, emailAddress, userType);
        }

        public void UpdateEmailAddress(string emailAddress)
        {
            EmailAddress = emailAddress;
            LastUpdated = DateTime.Now;
        }

        public void AddSession(Session session)
        {
            Sessions.Append(session);
            LastUpdated = DateTime.Now;
        }

        public void UpdateUserType(UserType userType)
        {
            UserType = userType;
            LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// The Id assigned to the person.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The name of the person.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The email address of the person.
        /// </summary>
        public string EmailAddress { get; private set; }

        /// <summary>
        /// Number of sessions the person has recorded.
        /// </summary>
        public IList<Session> Sessions { get; private set; }

        /// <summary>
        /// The last time the entity was updated.
        /// </summary>
        public DateTime LastUpdated { get; private set; }

        /// <summary>
        /// The user type.
        /// </summary>
        public UserType UserType { get; private set; }
    }
}