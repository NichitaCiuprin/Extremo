using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboardManager : MonoBehaviour
{
    public static InputKeyboardManager instance;
    private bool isDisableInput;

    public void Awake()
    {
        instance = this;
        isDisableInput = false;
    }
    public void Update()
    {
        Death deathInScene = DeathManager.instance.deathInScene;
        bool isControlDeath = !(deathInScene == null || deathInScene.state == Death.State.dead);
        if (isDisableInput) return;
        if (!isControlDeath) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DeathManager.instance.deathInScene.Left();
            TutorialManager.instance.isSwipeLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            DeathManager.instance.deathInScene.Up();
            TutorialManager.instance.isSwipeUp = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            DeathManager.instance.deathInScene.Right();
            TutorialManager.instance.isSwipeRight = true;
        }
    }
    public void SetActiveInput(bool isActive)
    {
        isDisableInput = isActive;    
    }
    public bool IsInputActive()
    {
        return isDisableInput;
    }
}
