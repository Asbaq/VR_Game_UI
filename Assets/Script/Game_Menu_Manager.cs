using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Game_Menu_Manager : MonoBehaviour
{
    public GameObject menu;
    public InputActionProperty ShowButton;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ShowButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
