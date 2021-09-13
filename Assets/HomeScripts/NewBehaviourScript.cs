﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    Renderer rend;
    int colorPicker = 0;
    public 

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit(Collider other)
    {
        switch (colorPicker)
        {
            case 0: rend.material.color = Color.white; break;
            case 1: rend.material.color = Color.cyan; break;
            case 2: rend.material.color = Color.blue; break;
            case 3: rend.material.color = Color.black; break;
            case 4: rend.material.color = Color.red; break;
            case 5: rend.material.color = Color.green; break;
            case 6: rend.material.color = Color.grey; break;
            case 7: rend.material.color = Color.magenta; break;
            case 8: rend.material.color = Color.yellow; break;
            case 9: rend.material.color = Color.gray; break;
        }
    }
}