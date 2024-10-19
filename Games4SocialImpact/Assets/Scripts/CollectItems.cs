using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public LayerMask pickable;

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.transform.gameObject.layer) & pickable) != 0)
        {
            
        }
    }
}
