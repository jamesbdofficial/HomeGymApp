using HomeGymApp.src.Entities;
using HomeGymApp.src.Repositories;

namespace HomeGymApp.src.Services
{
    /// <summary>
    /// Gym Service Class.
    /// </summary>
    public class GymService : IGymService
    {
        private readonly IValidationService validationService;
        private readonly IGymRepository gymRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="validationService">The Validation Service dependency.</param>
        /// <param name="gymRepository">The Gym Repository dependency.</param>
        public GymService(IValidationService validationService, IGymRepository gymRepository) 
        {
            this.validationService = validationService;
            this.gymRepository = gymRepository;
        }

        #region Create & Delete
        /// <inheritdoc/>
        public async Task<Gym> Create()
        {
            // These will be removed when dtos / commands / commandhandlers are added.
            Guid ownerId = Guid.NewGuid();
            string postcode = "XX11XX";
            string streetAddress = "1 Street Lane";
            string city = "City";
            List<Equipment> equipment = new List<Equipment>();

            validationService.EmptyGuidValidation(ownerId, "Owner Id");
            validationService.UKPostcodeValidation(postcode);

            Gym newGym = Gym.Create("Name", ownerId, streetAddress, city, postcode, equipment);

            await gymRepository.AddAsync(newGym);
            await gymRepository.SaveChangesAsync();

            return newGym;
        }

        /// <inheritdoc/>
        public async void Delete(Guid gymId)
        {
            await gymRepository.DeleteAsync(gymId);
            await gymRepository.SaveChangesAsync();
        }
        #endregion

        #region Update
        public async void Update(Guid gymId, Equipment equipment) 
        {
            // These will be removed when dtos / commands / commandhandlers are added.
            string streetAddress = "1 Street Lane";
            string city = "City";
            string postcode = "XX11XX";

            validationService.UKPostcodeValidation(postcode);

            Gym? gym = await gymRepository.GetByIdAsync(gymId);

            if (gym == null)
            {
                // ToDo: AddErrors
                return;
            }

            gym.AddEquipment(equipment);
            gym.UpdateAddress(streetAddress, city, postcode);

            await gymRepository.UpdateAsync(gym);
            await gymRepository.SaveChangesAsync();
        }
        #endregion
    }
}