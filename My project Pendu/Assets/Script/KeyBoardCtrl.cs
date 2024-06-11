using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardCtrl : MonoBehaviour
{
    public GameObject buttonPrefab;
    public List<string> keys;
    void CreateButton()
    {
        foreach (var key in keys)                                                           //permet la creation de mon clavier virtuelle 
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
