using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    public bool isBlockInput = false;
    public bool isClick = false;
    public bool isSwipeRight = false;
    public bool isSwipeLeft = false;
    public bool isSwipeUp = false;
    public GameObject left;
    public GameObject up;
    public GameObject right;
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;
    public GameObject frame5;
    public GameObject frame6;
    public GameObject frame7;
    public GameObject frame8;
    public GameObject click;

    public void Awake()
    {
        instance = this;
    }
    public void Click()
    {
        isClick = true;
    }
    public void StartTutorial()
    {
        isBlockInput = true;
        StartCoroutine(Tutorial());
    }
    private IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0;
        frame1.SetActive(true);
        click.SetActive(true);
        while (true)
        {
            if (isClick)
            {
                isClick = false;
                break;
            }
            isSwipeRight = false;
            isSwipeLeft = false;
            isSwipeUp = false;
            yield return null;
        }
        frame2.SetActive(true);
        while (true)
        {
            if (isClick)
            {
                isClick = false;
                break;
            }
            isSwipeRight = false;
            isSwipeLeft = false;
            isSwipeUp = false;
            yield return null;
        }
        click.SetActive(false);
        frame1.SetActive(false);
        frame2.SetActive(false);
        frame3.SetActive(false);
        Time.timeScale = 1;
        yield return new WaitForSeconds(2.2f);
        Time.timeScale = 0;
        frame3.SetActive(true);
        isBlockInput = false;
        while (true)
        {
            isClick = false;
            isSwipeLeft = false;
            isSwipeUp = false;
            if (isSwipeRight)
            {
                Time.timeScale = 1;
                frame3.SetActive(false);
                isSwipeRight = false;
                isBlockInput = true;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
        frame4.SetActive(true);
        click.SetActive(true);
        while (true)
        {
            if (isClick)
            {
                isClick = false;
                break;
            }
            isSwipeRight = false;
            isSwipeLeft = false;
            isSwipeUp = false;
            yield return null;
        }
        click.SetActive(false);
        frame4.SetActive(false);
        Time.timeScale = 1;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        frame5.SetActive(true);
        isBlockInput = false;
        while (true)
        {
            isClick = false;
            isSwipeRight = false;
            isSwipeUp = false;
            if (isSwipeLeft)
            {
                Time.timeScale = 1;
                frame5.SetActive(false);
                isSwipeLeft = false;
                isBlockInput = true;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
        frame6.SetActive(true);
        click.SetActive(true);
        while (true)
        {
            if (isClick)
            {
                isClick = false;
                break;
            }
            isSwipeRight = false;
            isSwipeLeft = false;
            isSwipeUp = false;
            yield return null;
        }
        click.SetActive(false);
        frame6.SetActive(false);
        right.SetActive(true);
        isBlockInput = false;
        while (true)
        {
            isClick = false;
            isSwipeLeft = false;
            isSwipeUp = false;
            if (isSwipeRight)
            {
                Time.timeScale = 1;
                right.SetActive(false);
                isSwipeRight = false;
                isBlockInput = true;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        up.SetActive(true);
        isBlockInput = false;
        while (true)
        {
            isClick = false;
            isSwipeLeft = false;
            isSwipeRight = false;
            if (isSwipeUp)
            {
                Time.timeScale = 1;
                up.SetActive(false);
                isSwipeUp = false;
                isBlockInput = true;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
        up.SetActive(true);
        isBlockInput = false;
        while (true)
        {
            isClick = false;
            isSwipeLeft = false;
            isSwipeRight = false;
            if (isSwipeUp)
            {
                Time.timeScale = 1;
                up.SetActive(false);
                isSwipeUp = false;
                isBlockInput = true;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
        up.SetActive(true);
        isBlockInput = false;
        while (true)
        {
            isClick = false;
            isSwipeLeft = false;
            isSwipeRight = false;
            if (isSwipeUp)
            {
                Time.timeScale = 1;
                up.SetActive(false);
                isSwipeUp = false;
                isBlockInput = true;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0;
        left.SetActive(true);
        isBlockInput = false;
        while (true)
        {
            isClick = false;
            isSwipeUp = false;
            isSwipeRight = false;
            if (isSwipeLeft)
            {
                Time.timeScale = 1;
                left.SetActive(false);
                isSwipeLeft = false;
                isBlockInput = true;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
        up.SetActive(true);
        isBlockInput = false;
        while (true)
        {
            isClick = false;
            isSwipeLeft = false;
            isSwipeRight = false;
            if (isSwipeUp)
            {
                Time.timeScale = 1;
                up.SetActive(false);
                isSwipeUp = false;
                isBlockInput = true;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
        frame7.SetActive(true);
        click.SetActive(true);
        while (true)
        {
            if (isClick)
            {
                isClick = false;
                break;
            }
            isSwipeRight = false;
            isSwipeLeft = false;
            isSwipeUp = false;
            yield return null;
        }
        click.SetActive(false);
        frame7.SetActive(false);
        Time.timeScale = 1;
        yield return new WaitForSeconds(1.3f);
        Time.timeScale = 0;
        right.SetActive(true);
        isBlockInput = false;
        while (true)
        {
            isClick = false;
            isSwipeLeft = false;
            isSwipeUp = false;
            if (isSwipeRight)
            {
                right.SetActive(false);
                isSwipeRight = false;
                isBlockInput = true;
                break;
            }
            yield return null;
        }
        Time.timeScale = 1;
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
        frame8.SetActive(true);
        click.SetActive(true);
        while (true)
        {
            if (isClick)
            {
                isClick = false;
                break;
            }
            isSwipeRight = false;
            isSwipeLeft = false;
            isSwipeUp = false;
            yield return null;
        }
        UIManager.instance.OnButtonExitLevel();
        //UIManager.instance.playerDeadMenu.SetActive(false);
        click.SetActive(false);
        Time.timeScale = 1;
        isBlockInput = false;
        frame8.SetActive(false);
    }
}
