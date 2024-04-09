using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField]
    private KitchenObjectSO kitchenObjectSo;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //Стол пустой
            if (player.HasKitchenObject())
            {
                //У игрока есть предмет в руках
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //У игрока нет предмета в руках
                
            }
        }
        else
        {
            //Что-то лежит
            if (player.HasKitchenObject())
            {
                //У игрока есть предмет в руках
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //У игрока в руках тарелка
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        //На прилавке стоит тарелка
                        if(plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else
            {
                //У игрока нет предмета в руках
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
