using HomeGymApp.src.Validation;

namespace HomeGymApp.src.Entities
{
    /// <summary>
    /// Gym entity.
    /// </summary>
    public class Gym
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the gym.</param>
        /// <param name="ownerId">The user Id of the owner</param>
        /// <param name="streetAddress">The street address of the gym.</param>
        /// <param name="city">The city the gym is in.</param>
        /// <param name="postCode">The postcode of the gym.</param>
        protected Gym(string name, Guid ownerId, string streetAddress, string city, string postCode)
        {
            Id = Guid.NewGuid();
            Name = name;
            OwnerId = ownerId;
            StreetAddress = streetAddress;
            City = city;
            PostCode = postCode;
        }

        public static Gym Create(string name, Guid ownerId, string streetAddress, string city, string postCode)
        {
            EntityValidation.EmptyGuidValidation(ownerId, "Owner Id");
            Gym newGym = new Gym(name, ownerId, streetAddress, city, postCode);
            return newGym;
        }

        public void UpdateAddress(string streetAddress, string city, string postCode)
        {
            StreetAddress = streetAddress;
            City = city;
            PostCode = postCode;
        }

        /// <summary>
        /// The Id of the gym.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The name of the gym.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The user Id of the owner.
        /// </summary>
        public Guid OwnerId { get; private set; }

        /// <summary>
        /// The street address of the gym.
        /// </summary>
        public string StreetAddress { get; private set; }

        /// <summary>
        /// The city the gym is in.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// The postcode of the gym.
        /// </summary>
        public string PostCode { get; private set; }
    }
}