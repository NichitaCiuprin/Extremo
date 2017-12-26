using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchManager : MonoBehaviour
{
    Vector2 lineLenght = new Vector2(0,0);
    bool isMakeMove = false;
    int max;

    public void Awake()
    {
        max = Display.displays[0].renderingWidth/30;
    }

    public void Update()
    {
        
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                isMakeMove = true;
                lineLenght.x = 0;
                lineLenght.y = 0;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                lineLenght += Input.GetTouch(0).deltaPosition;
                if(lineLenght.magnitude > max)
                {
                    if(isMakeMove)
                    {
                        isMakeMove = false;
                        float angle = Mathf.Atan2(lineLenght.y, lineLenght.x) * Mathf.Rad2Deg;

                        Death deathInScene = DeathManager.instance.deathInScene;
                        if (deathInScene == null) return;
                        if (deathInScene.state == Death.State.dead) return;
                        if (angle > 135 && angle < 180 || angle < -90 && angle > -180)
                        {
                            if (TutorialManager.instance.isBlockInput) return;
                            deathInScene.Left();
                            TutorialManager.instance.isSwipeLeft = true;
                        }
                        else if (angle > 0 && angle < 45 || angle < 0 && angle > -90)
                        {
                            if (TutorialManager.instance.isBlockInput) return;
                            deathInScene.Right();
                            TutorialManager.instance.isSwipeRight = true;
                        }
                        else
                        {
                            if (TutorialManager.instance.isBlockInput) return;
                            deathInScene.Up();
                            TutorialManager.instance.isSwipeUp = true;
                        }
                    }
                    
                }
            }
        }
    }
}
