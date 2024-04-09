using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [System.Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSo;
        public GameObject gameObject;
    }
    
    [SerializeField] 
    private PlateKitchenObject plateKitchenObject;

    [SerializeField] 
    private List<KitchenObjectSO_GameObject> kitchenObjectSoGameObjectList;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngedientAdded;
        
        foreach (KitchenObjectSO_GameObject kitchenObjectSoGameObject in kitchenObjectSoGameObjectList)
        {
            kitchenObjectSoGameObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngedientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (KitchenObjectSO_GameObject kitchenObjectSoGameObject in kitchenObjectSoGameObjectList)
        {
            if (kitchenObjectSoGameObject.kitchenObjectSo == e.KitchenObjectSO)
            {
                kitchenObjectSoGameObject.gameObject.SetActive(true);
            }
        }
    }
}
