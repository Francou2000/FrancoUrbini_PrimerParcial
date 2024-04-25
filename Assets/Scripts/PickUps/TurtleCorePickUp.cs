
public class TurtleCorePickUp : IPickUp
{
    public void PickUp()
    {
        Inventory.Instance.coreItems[2]++;
    }

}
