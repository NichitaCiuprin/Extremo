using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    public GameObject[] tutorialSteps;
    private bool isMoveNextInTutorial;

    public void Awake()
    {
        instance = this;
        isMoveNextInTutorial = false;
    }
    public void LateUpdate()
    {
        this.isMoveNextInTutorial = false;
    }
    public void StartTutorial()
    {
        StartCoroutine(StartTutorial_coroutine());
    }
    public void MoveNextInTutorial()
    {
        this.isMoveNextInTutorial = true;
    }

    private IEnumerator StartTutorial_coroutine()
    {
        StartCoroutine(ShowTutorialStep(2.5f, tutorialSteps[0]));
        while (!isMoveNextInTutorial)
            yield return null;
        yield return null;

        StartCoroutine(ShowTutorialStep(0f, tutorialSteps[1]));
        while (!isMoveNextInTutorial)
            yield return null;
        yield return null;

        StartCoroutine(ShowTutorialStep(2.3f, tutorialSteps[2]));
        InputKeyboardManager.instance.isControll_RightArrow = true;
        while (!isMoveNextInTutorial)
            yield return null;
        yield return null;
        
        StartCoroutine(ShowTutorialStep(1.5f, tutorialSteps[3]));
        InputKeyboardManager.instance.isControll_LeftArrow = true;
        while (!isMoveNextInTutorial)
            yield return null;
        yield return null;

        StartCoroutine(ShowTutorialStep(1.5f, tutorialSteps[4]));
        while (!isMoveNextInTutorial)
            yield return null;
        yield return null;

        StartCoroutine(ShowTutorialStep(0f, tutorialSteps[5]));
        InputKeyboardManager.instance.isControll_RightArrow = true;
        while (!Input.GetKeyDown(KeyCode.RightArrow))
            yield return null;
        yield return null;

        StartCoroutine(ShowTutorialStep(1f, tutorialSteps[6]));
        InputKeyboardManager.instance.isControll_UpArrow = true;
        while (!Input.GetKeyDown(KeyCode.UpArrow))
            yield return null;
        yield return null;

        StartCoroutine(ShowTutorialStep(1.5f, tutorialSteps[7]));
        InputKeyboardManager.instance.isControll_UpArrow = true;
        while (!Input.GetKeyDown(KeyCode.UpArrow))
            yield return null;
        yield return null;

        StartCoroutine(ShowTutorialStep(0.5f, tutorialSteps[8]));
        InputKeyboardManager.instance.isControll_RightArrow = true;
        while (!Input.GetKeyDown(KeyCode.RightArrow))
            yield return null;
        yield return null;

        StartCoroutine(ShowTutorialStep(1.5f, tutorialSteps[9]));
        InputKeyboardManager.instance.isControll_LeftArrow = true;
        while (!Input.GetKeyDown(KeyCode.LeftArrow))
            yield return null;
        yield return null;

        StartCoroutine(ShowTutorialStep(1.5f, tutorialSteps[10]));
        while (!isMoveNextInTutorial)
            yield return null;
        yield return null;

        StartCoroutine(ShowTutorialStep(2.3f, tutorialSteps[11]));
        while (!isMoveNextInTutorial)
            yield return null;
        yield return null;

        GameManager.instance.Exitlevel();
    }
    private IEnumerator ShowTutorialStep(float timeBeforeShowStep, GameObject stepToShow)
    {
        InputKeyboardManager.instance.isControll_LeftArrow = false;
        InputKeyboardManager.instance.isControll_RightArrow = false;
        InputKeyboardManager.instance.isControll_UpArrow = false;
        yield return new WaitForSeconds(timeBeforeShowStep);
        foreach (var step in tutorialSteps)
        {
            step.SetActive(false);
        }
        Time.timeScale = 0;
        stepToShow.SetActive(true);
        InputKeyboardManager.instance.isInputKeyboardActive = true;
        while (!isMoveNextInTutorial)
        {
            yield return null;
        }
        yield return null;
        InputKeyboardManager.instance.isInputKeyboardActive = false;
        Time.timeScale = 1;
        stepToShow.SetActive(false);
    }
}

