namespace Domain
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }

        public Actor(string actorName, DateTime dOB, int id)
        {
            Name = actorName;
            DOB = dOB;
            Id = id;    
        }

    }
}