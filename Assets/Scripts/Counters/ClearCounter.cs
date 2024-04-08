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
            }
            else
            {
                //У игрока нет предмета в руках
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
