namespace Boxers.Entities
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public virtual Boxer Boxer { get; set; }
    }
}
