public class DeliveryCounter : BaseCounter
{
    public static DeliveryCounter Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                //У игрока в руках тарелка
                DeliveryManager.Instance.DeliveryRecipe(plateKitchenObject);
                
                player.GetKitchenObject().DestroySelf();
            }
        }
    }
}
