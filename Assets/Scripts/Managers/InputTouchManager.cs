using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchManager : MonoBehaviour
{
    public static InputTouchManager instance;

    public Vector2 strokeVector2;
    public bool isStrokeCreationInProgress;
    public int maxStrokeLenghtAllowed;
    public bool isInputTouchEnabled;
    public bool isWasSwipeRightInFrame;
    public bool isWasSwipeUpInFrame;
    public bool isWasSwipeLeftInFrame;

    public void Awake()
    {
        strokeVector2 = new Vector2(0, 0);
        isStrokeCreationInProgress = false;
        maxStrokeLenghtAllowed = Display.displays[0].renderingWidth/30;
        isInputTouchEnabled = true;
    }
    public void Update()
    {
        isWasSwipeRightInFrame = false;
        isWasSwipeUpInFrame = false;
        isWasSwipeLeftInFrame = false;
        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                isStrokeCreationInProgress = true;
                strokeVector2.x = -0;
                strokeVector2.y = 0;
            }
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                strokeVector2 += Input.GetTouch(0).deltaPosition;
                if(strokeVector2.magnitude > maxStrokeLenghtAllowed)
                {
                    if(isStrokeCreationInProgress)
                    {
                        isStrokeCreationInProgress = false;
                        float angle = Mathf.Atan2(strokeVector2.y, strokeVector2.x) * Mathf.Rad2Deg;

                        Death deathInScene = DeathManager.instance.deathInScene;
                        if (deathInScene == null) return;
                        if (deathInScene.state == Death.State.dead) return;
                        if (isInputTouchEnabled) return;
                        
                        if (angle > 135 && angle < 180 || angle < -90 && angle > -180)
                        {
                            isWasSwipeLeftInFrame = true;
                            deathInScene.Left();
                            TutorialManager.instance.isSwipeLeft = true;
                        }
                        else if (angle > 0 && angle < 45 || angle < 0 && angle > -90)
                        {
                            isWasSwipeRightInFrame = true;
                            deathInScene.Right();
                            TutorialManager.instance.isSwipeRight = true;
                        }
                        else
                        {
                            isWasSwipeUpInFrame = true;
                            deathInScene.Up();
                            TutorialManager.instance.isSwipeUp = true;
                        }
                    }
                }
            }
        }
    }
}
