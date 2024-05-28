using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardCtrl : MonoBehaviour
{
    public GameObject buttonPrefab;
    public List<string> keys;
    void CreateButton()
    {
        foreach (var key in keys) 
        {
            GameObject go = Instantiate(buttonPrefab);
            go.transform.parent = transform;
            KeyControl keyControl = go.GetComponent<KeyControl>();  
            keyControl.Init(key);
        }
    }
    private void Start()
    {
        CreateButton();
    }
}
