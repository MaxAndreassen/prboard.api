namespace foundation.Entities.Contracts
{
    public interface IEntity<TKey> : IEntity, IUuid, ICrudDates where TKey : struct
    {
        TKey Id { get; set; }
    }

    public interface IEntity
    {
    }
}