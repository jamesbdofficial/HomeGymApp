namespace HomeGymApp.src.Services
{
    public interface IValidationService
    {
        public void EmptyGuidValidation(Guid id, string fieldName);

        public void ExerciseValidation(decimal weight, Dictionary<int, int> setsAndReps);

        public void UKPostcodeValidation(string postcode);
    }
}