namespace MA.DomainEntities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public bool IsActive { get; set; }
    }
}
