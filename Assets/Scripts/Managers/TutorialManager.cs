using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    [HideInInspector]
    public bool isWasTutorialClick;

    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;
    public GameObject frame5;
    public GameObject frame6;
    public GameObject frame7;
    public GameObject frame8;
    public GameObject frame9;
    public GameObject frame10;
    public GameObject frame11;
    public GameObject frame12;

    public void Awake()
    {
        instance = this;
        isWasTutorialClick = false;
    }
    public void LateUpdate()
    {
        this.isWasTutorialClick = false;
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
        InputKeyboardManager inputKeyboardManager = InputKeyboardManager.instance;
        yield return new WaitForSeconds(2.5f);

        HideFrames();
        ShowFrame(frame1);
        while (!isWasTutorialClick)
            yield return null;
        yield return null;

        HideFrames();
        ShowFrame(frame2);
        while (!isWasTutorialClick)
            yield return null;

        HideFrames();
        yield return new WaitForSeconds(2.3f);
        ShowFrame(frame3);
        inputKeyboardManager.isInputKeyboardActive = true;
        while (!Input.GetKeyDown(KeyCode.RightArrow))
            yield return null;
        inputKeyboardManager.isInputKeyboardActive = false;

        HideFrames();
        yield return new WaitForSeconds(1.5f);
        ShowFrame(frame4);
        inputKeyboardManager.isInputKeyboardActive = true;
        while (!Input.GetKeyDown(KeyCode.LeftArrow))
            yield return null;
        inputKeyboardManager.isInputKeyboardActive = false;

        HideFrames();
        yield return new WaitForSeconds(1.5f);
        ShowFrame(frame5);
        while (!isWasTutorialClick)
            yield return null;

        HideFrames();
        ShowFrame(frame6);
        inputKeyboardManager.isInputKeyboardActive = true;
        while (!Input.GetKeyDown(KeyCode.RightArrow))
            yield return null;
        inputKeyboardManager.isInputKeyboardActive = false;

        HideFrames();
        yield return new WaitForSeconds(1f);
        ShowFrame(frame7);
        inputKeyboardManager.isInputKeyboardActive = true;
        while (!Input.GetKeyDown(KeyCode.UpArrow))
            yield return null;
        inputKeyboardManager.isInputKeyboardActive = false;

        HideFrames();
        yield return new WaitForSeconds(1.5f);
        ShowFrame(frame8);
        inputKeyboardManager.isInputKeyboardActive = true;
        while (!Input.GetKeyDown(KeyCode.UpArrow))
            yield return null;
        inputKeyboardManager.isInputKeyboardActive = false;

        HideFrames();
        yield return new WaitForSeconds(0.5f);
        ShowFrame(frame9);
        inputKeyboardManager.isInputKeyboardActive = true;
        while (!Input.GetKeyDown(KeyCode.RightArrow))
            yield return null;
        inputKeyboardManager.isInputKeyboardActive = false;

        HideFrames();
        yield return new WaitForSeconds(1.5f);
        ShowFrame(frame10);
        inputKeyboardManager.isInputKeyboardActive = true;
        while (!Input.GetKeyDown(KeyCode.LeftArrow))
            yield return null;
        inputKeyboardManager.isInputKeyboardActive = false;

        HideFrames();
        yield return new WaitForSeconds(1.5f);
        ShowFrame(frame11);
        while (!isWasTutorialClick)
            yield return null;
        yield return null;

        HideFrames();
        yield return new WaitForSeconds(2.3f);
        ShowFrame(frame12);
        while (!isWasTutorialClick)
            yield return null;

        HideFrames();

    }
    private void ShowFrame(GameObject frameToShow)
    {
        Time.timeScale = 0;
        frameToShow.SetActive(true);
    }
    private void HideFrames()
    {
        Time.timeScale = 1;
        frame1.SetActive(false);
        frame2.SetActive(false);
        frame3.SetActive(false);
        frame4.SetActive(false);
        frame5.SetActive(false);
        frame6.SetActive(false);
        frame7.SetActive(false);
        frame8.SetActive(false);
        frame9.SetActive(false);
        frame10.SetActive(false);
        frame11.SetActive(false);
        frame12.SetActive(false);
    }
}
