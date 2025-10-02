namespace HomeGymApp.src.Entities
{
    public class ExerciseSet
    {
        protected ExerciseSet(int setNumber, int reps, decimal weight)
        {
            Id = Guid.NewGuid();
            SetNumber = setNumber;
            Reps = reps;
            Weight = weight;
        }

        public static ExerciseSet Create(int setNumber, int reps, decimal weight)
        {
            return new ExerciseSet(setNumber, reps, weight);
        }

        /// <summary>
        /// Id of the set.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The set number (1, 2, 3, etc.)
        /// </summary>
        public int SetNumber { get; private set; }

        /// <summary>
        /// Number of reps completed in this set.
        /// </summary>
        public int Reps { get; private set; }

        /// <summary>
        /// Weight used for this set.
        /// </summary>
        public decimal Weight { get; private set; }

        /// <summary>
        /// Optional: Rate of Perceived Exertion (1-10 scale).
        /// </summary>
        public int? RPE { get; private set; }

        public void SetRPE(int rpe)
        {
            if (rpe < 1 || rpe > 10)
                throw new ArgumentException("RPE must be between 1 and 10");
            RPE = rpe;
        }
    }
}
