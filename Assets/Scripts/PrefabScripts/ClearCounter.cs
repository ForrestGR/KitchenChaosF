using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectsSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] bool testing;

    private KitchenObject kitchenObject;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetKitchenObjectParent(secondClearCounter);                
            }
        }
    }



    public void Interact(Player player)
    {
        //Debug.Log("Interact");

        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);            
        } else
        {
            //Give the object to the player
            //kitchenObject.SetClearCounter(player);
            Debug.Log(kitchenObject.GetKitchenObjectParent());
        }
        //Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectsSO());

    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject (KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() 
    {
        return kitchenObject; 
    }
    
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
