using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboardManager : MonoBehaviour
{
    public static InputKeyboardManager instance;

    public bool isInputKeyboardActive;
    public bool isControllDeath;
    public bool isControllDeath_LeftArrow;
    public bool isControllDeath_RightArrow;
    public bool isControllDeath_UpArrow;

    public void Awake()
    {
        instance = this;
        isInputKeyboardActive = true;
        isControllDeath = true;
    }
    public void Update()
    {
        if (!isInputKeyboardActive) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (isControllDeath)
            {
                if(DeathManager.instance.deathInScene != null)
                    DeathManager.instance.deathInScene.DeflectLeft();
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isControllDeath)
            {
                if (DeathManager.instance.deathInScene != null)
                    DeathManager.instance.deathInScene.DeflectUp();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isControllDeath)
            {
                if (DeathManager.instance.deathInScene != null)
                    DeathManager.instance.deathInScene.DeflectRight();
            }
        }
    }
}
