using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : MonoBehaviour
{


    [SerializeField] private KitchenObjectSO kitchenObjectsSO;
    [SerializeField] private Transform counterTopPoint;
    
    private KitchenObject kitchenObject;




    public void Interact(Player player)
    {
        //Debug.Log("Interact");

        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            //Give the object to the player
            kitchenObject.SetKitchenObjectParent(player);

        }
        //Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectsSO());

    }
}
