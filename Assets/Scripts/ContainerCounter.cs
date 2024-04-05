using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    
    [SerializeField] 
    private KitchenObjectSO kitchenObjectSo;

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            //У игрока нет предмета
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            
        }
    }
}
