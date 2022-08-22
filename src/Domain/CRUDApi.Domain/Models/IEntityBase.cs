namespace CRUDApi.Models
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
    }
}
