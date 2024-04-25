
public class MushroomCorePickUp : IPickUp
{
    public void PickUp()
    {
        Inventory.Instance.coreItems[3]++;
    }
}
