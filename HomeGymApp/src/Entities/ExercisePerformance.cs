namespace HomeGymApp.src.Entities
{
    /// <summary>
    /// The Exercise Performance Entity.
    /// This is what links an exercise to a session
    /// </summary>
    public class ExercisePerformance
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="exerciseId">The Id of the exercise performed.</param>
        /// <param name="weight">Weight of the exercise performance.</param>
        /// <param name="setsAndReps">Sets and reps of the exercise.</param>
        protected ExercisePerformance(Exercise exercise, Guid exerciseId, decimal weight, Dictionary<int, int> setsAndReps)
        {
            Id = Guid.NewGuid();
            Exercise = exercise;
            ExerciseId = exerciseId;
            Sets = new List<ExerciseSet>();
        }

        public static ExercisePerformance RecordPerformance(Exercise exercise, Guid exerciseId, decimal weight, Dictionary<int, int> setsAndReps)
        {
            return new ExercisePerformance(exercise, exerciseId, weight, setsAndReps);
        }

        public void AddSet(int setNumber, int reps, decimal weight)
        {
            ExerciseSet newSet = ExerciseSet.Create(setNumber, reps, weight);
            Sets.Add(newSet);
        }


        /// <summary>
        /// Id of the Exercise Performance.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The Id of the exercise performed.
        /// </summary>
        public Exercise Exercise { get; private set; }

        /// <summary>
        /// The Id of the exercise performed.
        /// </summary>
        public Guid ExerciseId { get; private set; }

        /// <summary>
        /// Sets and reps of the exercise.
        /// </summary>
        public IList<ExerciseSet> Sets { get; private set; }
    }
}