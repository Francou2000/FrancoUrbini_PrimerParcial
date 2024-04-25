
public class CactusCorePickUp : IPickUp
{
    public void PickUp()
    {
        Inventory.Instance.coreItems[1]++;
    }
}
