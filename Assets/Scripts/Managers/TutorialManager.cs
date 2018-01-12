using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    public bool isWasTutorialClick;
    public bool isWasDeflectLeft;
    public bool isWasDeflectRight;
    public bool isWasDeflectUp;

    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;
    public GameObject frame5;
    public GameObject frame6;
    public GameObject frame7;
    public GameObject frame8;

    public void Awake()
    {
        instance = this;
        isWasTutorialClick = false;
    }
    public void StartTutorial()
    {
        InputKeyboardManager.instance.isInputKeyboardActive = false;
        StartCoroutine(Tutorial());
    }
    public void OnTutorialButton()
    {
        this.isWasTutorialClick = true;
    }
    private IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0;
        frame1.SetActive(true);
        while (!isWasTutorialClick)
        {
            yield return null;
        }
        isWasTutorialClick = false;
        frame1.SetActive(false);
        frame2.SetActive(true);
        while (!isWasTutorialClick)
        {
            yield return null;
        }
        Time.timeScale = 1;
        isWasTutorialClick = false;
        frame2.SetActive(false);
        yield return new WaitForSeconds(2f);
        frame3.SetActive(true);
        Time.timeScale = 0;
        InputKeyboardManager.instance.isInputKeyboardActive = true;
        while (!Input.GetKeyDown(KeyCode.RightArrow))
        {
            yield return null;
        }
        Time.timeScale = 1;
        frame3.SetActive(false);
        frame4.SetActive(false);
        //frame2.SetActive(false);
        //Time.timeScale = 1;
        //yield return new WaitForSeconds(2.2f);
        //Time.timeScale = 0;
        //frame3.SetActive(true);
        //InputKeyboardManager.instance.isInputKeyboardActive = true;
        //while (!InputTouchManager.instance.isWasSwipeRightInFrame)
        //{
        //    yield return null;
        //}
        //Time.timeScale = 1;
        //frame3.SetActive(false);
        //InputKeyboardManager.instance.isInputKeyboardActive = true;

        //yield return new WaitForSeconds(0.5f);
        //Time.timeScale = 0;
        //frame4.SetActive(true);
        //while (!isWasTutorialClick)
        //{
        //    yield return null;
        //}
        //frame4.SetActive(false);
        //Time.timeScale = 1;
        //yield return new WaitForSeconds(1f);
        //Time.timeScale = 0;
        //frame5.SetActive(true);
        //InputKeyboardManager.instance.isInputKeyboardActive = true;
        //while (!isWasTutorialClick)
        //{
        //    yield return null;
        //}
        //yield return new WaitForSeconds(1.5f);
        //Time.timeScale = 0;
        //frame6.SetActive(true);
        //while (!isWasTutorialClick)
        //{
        //    yield return null;
        //}
        //frame6.SetActive(false);
        //InputKeyboardManager.instance.isInputKeyboardActive = true;
        //while (!isWasTutorialClick)
        //{
        //    yield return null;
        //}
        //yield return new WaitForSeconds(1f);
        //Time.timeScale = 0;
        ////up
        //InputKeyboardManager.instance.isInputKeyboardActive = true;
        //while (!isWasTutorialClick)
        //{
        //    yield return null;
        //}
        //yield return new WaitForSeconds(1.5f);
        //Time.timeScale = 0;
        //up.SetActive(true);
        //InputKeyboardManager.instance.SetActiveInput(true);
        //while (!isWasTutorialClick)
        //{
        //    yield return null;
        //}
        //yield return new WaitForSeconds(0.5f);
        //Time.timeScale = 0;
        //up.SetActive(true);
        //InputKeyboardManager.instance.SetActiveInput(true);
        //while (!isWasTutorialClick)
        //{
        //    yield return null;
        //}
        //yield return new WaitForSeconds(1.5f);
        //Time.timeScale = 0;
        //left.SetActive(true);
        //InputKeyboardManager.instance.SetActiveInput(true);
        //while (!isWasTutorialClick)
        //{
        //    yield return null;
        //}
        //yield return new WaitForSeconds(0.5f);
        //Time.timeScale = 0;
        //up.SetActive(true);
        //InputKeyboardManager.instance.SetActiveInput(true);
        //while (!isWasTutorialClick)
        //{
        //    yield return null;
        //}
    }
}
