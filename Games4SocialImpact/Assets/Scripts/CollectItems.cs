using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public LayerMask pickable;

    public Dictionary<string, int> items = new Dictionary<string, int>
    {
        {"Apple", 2},
        {"Bread", 1},
        {"Carrot", 3},
    };

    void OnTriggerEnter(Collider other)
    {
        if (((1 << other.transform.gameObject.layer) & pickable) != 0)
        {
            string[] words = other.name.Split(' ');

            if (items.ContainsKey(words[0]))
            {
                items[words[0]]--;
                Destroy(other.transform.gameObject);
            }

            if (hasSucceeded())
            {
                Debug.Log("You have succeeded!");
            }
        }
    }

    bool hasSucceeded() {
        bool hasSucceeded = true;
        foreach (var count in items.Values)
        {
            if (count > 0)
            {
                hasSucceeded = false;
                break;
            }
        }
        return hasSucceeded;
    }
}
