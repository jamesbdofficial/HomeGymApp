using HomeGymApp.src.Models;

namespace HomeGymApp.src.Entities
{
    /// <summary>
    /// Work item entity - used to track any work or changes done to the gym.
    /// </summary>
    public class WorkItem
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the work item.</param>
        /// <param name="description">Description of the works done.</param>
        /// <param name="recordedDateTime">Date time the work item was recorded.</param>
        protected WorkItem(string name, string description, DateTime recordedDateTime)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            RecordedDateTime = recordedDateTime;
            CompletedDateTime = null;
        }

        /// <summary>
        /// The Id of the work item.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// The name of the work item.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Description of the works done.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Date time the work item was recorded.
        /// </summary>
        public DateTime RecordedDateTime { get; private set; }

        /// <summary>
        /// Date time the work item was completed.
        /// </summary>
        public DateTime? CompletedDateTime { get; private set; }

        /// <summary>
        /// The person the work item was completed by.
        /// </summary>
        public Person? CompletedBy { get; set; }

        public static WorkItem Create(string name, string description, DateTime recordedDateTime)
        {
            return new WorkItem(name, description, recordedDateTime);
        }

        public void CompleteWork(DateTime? completedDateTime, Person completedBy)
        {
            CompletedDateTime = completedDateTime != null ? completedDateTime : DateTime.Now;
            CompletedBy = completedBy;
        }
    }
}