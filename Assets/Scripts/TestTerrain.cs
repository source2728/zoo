using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using GameFramework.Task;
using UnityEngine;

public class TestTerrain : MonoBehaviour
{
    public UIPanel d;

    // Use this for initialization
    void Start()
    {
        var dd = d.ui as GButton;
//        dd.touchable = true;
        dd.onClick.Set(() => { Debug.Log("123"); });
    }

    // Update is called once per frame
    void Update()
    {
        TaskManager
    }
}
