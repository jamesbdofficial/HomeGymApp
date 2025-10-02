using System.Text.RegularExpressions;

namespace HomeGymApp.src.Services
{
    public class ValidationService : IValidationService
    {
        public void EmptyGuidValidation(Guid id, string fieldName)
        {
            if (id == Guid.Empty)
            {
                ThrowEmptyOrNullException(fieldName);
            }
        }

        public void ExerciseValidation(decimal weight, Dictionary<int, int> setsAndReps)
        {
            if (weight <= 0)
            {
                ThrowCannotBeZeroException("Weight");
                return;
            }

            if (setsAndReps == null || setsAndReps.Count == 0)
            {
                ThrowEmptyOrNullException("Sets and Reps");
                return;
            }

            foreach (var set in setsAndReps)
            {
                if (set.Key <= 0)
                {
                    ThrowCannotBeZeroException("Set number");
                }

                if (set.Value <= 0)
                {
                    ThrowCannotBeZeroException("Rep number");
                }
            }
        }

        public void UKPostcodeValidation(string postcode)
        {
            if (string.IsNullOrWhiteSpace(postcode))
            {
                ThrowEmptyOrNullException("Postcode");
            }

            string pattern = @"^[A-Z]{1,2}\d{1,2}\s?\d[A-Z]{2}$";

            if (!Regex.IsMatch(postcode.ToUpper(), pattern))
            {
                throw new ArgumentException("Postcode must be a valid UK postcode format");
            }
        }

        private static void ThrowEmptyOrNullException(string fieldName)
        {
            throw new ArgumentException("Field " + fieldName + " cannot be null or empty.");
        }

        private static void ThrowCannotBeZeroException(string fieldName)
        {
            throw new ArgumentException(fieldName + " must be greater than zero.");
        }
    }
}