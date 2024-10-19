using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodoManager : MonoBehaviour
{

    public Dictionary<string, int> items = new Dictionary<string, int>
    {
        {"Apple", 3},
        {"Pencil", 1},
        {"Chicken", 1},
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Apple: " + items["Apple"] + ", Pencil: " + items["Pencil"] + ", Chicken: " + items["Chicken"]);

    }
}
