namespace HomeGymApp.src.Validation
{
    public class EntityValidation
    {
        public static void EmptyGuidValidation(Guid id, string fieldName)
        {
            if (id == Guid.Empty) 
            {
                throw new ArgumentException("Field " +  fieldName + " cannot be null or empty.");
            }
        }
    }
}