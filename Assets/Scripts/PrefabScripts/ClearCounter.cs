using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectsSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;

    private KitchenObject kitchenObject;


    public void Interact()
    {
        //Debug.Log("Interact");

        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefab, counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;

            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.SetClearCounter(this);
        } else
        {
            Debug.Log(kitchenObject.GetClearCounter());
        }
        //Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectsSO());

    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }
}
