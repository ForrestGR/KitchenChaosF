using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : MonoBehaviour
{
    public void Interact()
    {
        
        Debug.Log("AK47 goes boom mf");
        Destroy(gameObject);
    }
}
