namespace Library.Infrastructure.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }

        bool IsDeleted { get; set; }
    }
}
