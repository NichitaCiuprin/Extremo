using System;
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
        instance = this;
        strokeVector2 = new Vector2(0, 0);
        isStrokeCreationInProgress = false;
        maxStrokeLenghtAllowed = Display.displays[0].renderingWidth/30;
        isInputTouchEnabled = true;
    }
    public void OnGUI()
    {
    }
    public void Update()
    {
        bool isInputTouchActive = Input.touchCount > 0 && isInputTouchEnabled;
        if (isInputTouchActive)
        {
            OnTouchBegan();
            OnTouchMoved();
        }
    }
    public void LateUpdate()
    {
        ResetInputState();
    }

    private void ResetInputState()
    {
        isWasSwipeRightInFrame = false;
        isWasSwipeUpInFrame = false;
        isWasSwipeLeftInFrame = false;
    }

    private void OnTouchBegan()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            isStrokeCreationInProgress = true;
            strokeVector2.x = 0;
            strokeVector2.y = 0;
        }
    }
    private void OnTouchMoved()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            strokeVector2 += Input.GetTouch(0).deltaPosition;
            if (strokeVector2.magnitude < maxStrokeLenghtAllowed) return;
            if (!isStrokeCreationInProgress) return;
            isStrokeCreationInProgress = false;
            float angle = Mathf.Atan2(strokeVector2.y, strokeVector2.x) * Mathf.Rad2Deg;
            //stroke left
            if (angle > 135 && angle < 180 || angle < -90 && angle > -180)
            {
                //Death controll
                DeathManager.instance.deathInScene?.DeflectLeft();
                //input
                isWasSwipeLeftInFrame = true;
            }
            //stroke right
            else if (angle > 0 && angle < 45 || angle < 0 && angle > -90)
            {
                //Death controll
                DeathManager.instance.deathInScene?.DeflectRight();
                //input
                isWasSwipeRightInFrame = true;
            }
            //stroke up
            else
            {
                //Death controll
                DeathManager.instance.deathInScene?.DeflectUp();
                //input
                isWasSwipeUpInFrame = true;
            }
        }
    }
}
