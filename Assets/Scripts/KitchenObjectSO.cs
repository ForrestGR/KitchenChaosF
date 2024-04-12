using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject
{
    public Transform prefab;        //public, read only data container, not used for writing, therefore its ok my friend public accessible for everyone, no need for getter and setter
    public Sprite sprite;
    public string objectName;
}
