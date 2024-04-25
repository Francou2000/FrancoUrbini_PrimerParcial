
public class SlimeCorePickUp : IPickUp
{
    public void PickUp()
    {
        Inventory.Instance.coreItems[0]++;
    }
}
