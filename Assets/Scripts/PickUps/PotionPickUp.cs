
public class PotionPickUp : IPickUp
{
    public void PickUp()
    {
        Inventory.Instance.potions++;
    }
}
