namespace DryPro.Inventory.Core.Services.Base
{
    public interface IEntityConverter<T> where T : class
    {
        T Convert();
    }
}