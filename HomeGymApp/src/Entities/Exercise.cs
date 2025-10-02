namespace HomeGymApp.src.Entities
{
    /// <summary>
    /// The exercise entity.
    /// </summary>
    public class Exercise
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the exercise</param>
        /// <param name="weight">The weight used during the exercise</param>
        /// <param name="setsAndReps">The sets and their corresponding reps of the exercise.</param>
        protected Exercise(string name, decimal weight, string description, IList<string> primaryMuscleGroups, IList<string> secondaryMuscleGroups) 
        {
            Id = Guid.NewGuid();
            Name = name;
            Weight = weight;
            Description = description;
            PrimaryMuscleGroups = primaryMuscleGroups;
            SecondaryMuscleGroups= secondaryMuscleGroups;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Weight { get; set; }

        public string Description { get; set;}

        public IList<string> PrimaryMuscleGroups { get; set; }

        public IList<string> SecondaryMuscleGroups { get; set; }

        public static Exercise Record(string name, decimal weight, string description, IList<string> primaryMuscleGroups, IList<string> secondaryMuscleGroups) 
        {
            Exercise exercise = new Exercise(name, weight, description, primaryMuscleGroups, secondaryMuscleGroups);
            return exercise;
        }
    }
}