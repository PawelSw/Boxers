namespace Boxers.Entities
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int BoxerId { get; set; }
        public virtual Boxer Boxer { get; set; }
    }
}
