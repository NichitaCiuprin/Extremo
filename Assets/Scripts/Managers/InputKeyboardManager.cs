using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboardManager : MonoBehaviour
{
    public void Update()
    {
        Death deathInScene = DeathManager.instance.deathInScene;
        bool isControlDeath = !(deathInScene == null || deathInScene.state == Death.State.dead);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TutorialManager.instance.isClick = true;
            if (TutorialManager.instance.isBlockInput) return;
            if (!isControlDeath) return;
            deathInScene.Left();
            TutorialManager.instance.isSwipeLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TutorialManager.instance.isClick = true;
            if (TutorialManager.instance.isBlockInput) return;
            if (!isControlDeath) return;
            deathInScene.Up();
            TutorialManager.instance.isSwipeUp = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TutorialManager.instance.isClick = true;
            if (TutorialManager.instance.isBlockInput) return;
            if (!isControlDeath) return;
            deathInScene.Right();
            TutorialManager.instance.isSwipeRight = true;
        }
    }
}
