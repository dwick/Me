namespace Me.Web.Mvc.Models.DomainModel
{
    public interface IEntityWithTypedId<T>
    {
        T Id { get; }
    }
}