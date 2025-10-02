namespace HomeGymApp.src.Entities
{
    public class Equipment
    {
        protected Equipment(Guid id, string name, DateTime installedDate)
        {
            Id = id;
            Name = name;
            InstalledDate = installedDate;
        }

        public static Equipment Create(string name, DateTime installedDate)
        {
            Equipment newEqupiment = new Equipment(Guid.NewGuid(), name, installedDate);
            return newEqupiment;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public DateTime InstalledDate { get; private set; }
    }
}