using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TodoEntry : MonoBehaviour
{

    CollectItems tdm;
    Toggle tg;
    TMP_Text txt;

    // Start is called before the first frame update
    void Start()
    {
        tdm = GameObject.FindAnyObjectByType<CollectItems>();
        
    }

    // Update is called once per frame
    void Update()
    {
        string name = "";
        List<string> keysList = tdm.items.Keys.ToList<string>();
        for (int i = 0; i < tdm.items.Keys.Count; i++)
        {
            name = keysList[i];
            
            txt = gameObject.transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            
            tg = gameObject.transform.GetChild(i).transform.GetChild(1).gameObject.GetComponent<Toggle>();
            if (tdm.items[name] == 0) {
                tg.isOn = true;
            }
            txt.text = name + " ×" + tdm.items[name];
        }
        // Debug.Log("----");
        // Debug.Log(tdm.items[name]);
        // Debug.Log("----");
        
    }
}
