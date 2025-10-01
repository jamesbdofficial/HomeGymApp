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
        protected Exercise(string name, decimal weight, Dictionary<int, int> setsAndReps) 
        {
            Name = name;
            Weight = weight;
            SetsAndReps = setsAndReps;
        }

        public string Name { get; set; }

        public decimal Weight { get; set; }

        public Dictionary<int, int> SetsAndReps { get; set;}

        public static Exercise Record(string name, decimal weight, Dictionary<int, int> setsAndReps) 
        {
            Exercise exercise = new Exercise(name, weight, setsAndReps);
            return exercise;
        }
    }
}