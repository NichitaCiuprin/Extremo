using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboardManager : MonoBehaviour
{
    public static InputKeyboardManager instance;

    public bool isInputKeyboardActive;

    public bool isControll_LeftArrow;
    public bool isControll_RightArrow;
    public bool isControll_UpArrow;

    public void Awake()
    {
        instance = this;
        isInputKeyboardActive = true;
    }
    public void Update()
    {
        if (!isInputKeyboardActive)
            return;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnLeftArrow();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnUpArrow();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnRightArrow();
        }
    }
     
    private void OnUpArrow()
    {
        if (!isControll_UpArrow)
            return;
        if (DeathManager.instance.deathInScene != null)
            DeathManager.instance.deathInScene.DeflectUp();
        TutorialManager.instance.MoveNextInTutorial();
    }
    private void OnLeftArrow()
    {
        if (!isControll_LeftArrow)
            return;
        if (DeathManager.instance.deathInScene != null)
            DeathManager.instance.deathInScene.DeflectLeft();
        TutorialManager.instance.MoveNextInTutorial();
    }
    private void OnRightArrow()
    {
        if (!isControll_RightArrow)
            return;
        if (DeathManager.instance.deathInScene != null)
            DeathManager.instance.deathInScene.DeflectRight();
        TutorialManager.instance.MoveNextInTutorial();
    }
}
