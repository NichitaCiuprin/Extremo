using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;

    public GameObject startMenu;
    public GameObject playerDeadMenu;
    public GameObject gameHood;

    public GameObject resetButton;

    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        ShowStartMenu();
        HidePlayerDeadMenu();
    }

    public void OnButton_StartGame()
    {
        StartCoroutine(OnButtonStartGame_Coroutine());
    }
    public void OnButton_Tutorial()
    {
        StartCoroutine(OnButtonTutorial_Coroutine());
    }
    public void OnButton_ExitLevel()
    {
        StartCoroutine(OnButtonExitLevel_Coroutine());
    }
    public void OnButton_Restart()
    {
        StartCoroutine(OnButtonRestart_Coroutine());
    }
    public void OnButton_ExitGame()
    {
        StartCoroutine(OnButtonExitGame_Coroutine());
        
    }
    private IEnumerator OnButtonStartGame_Coroutine()
    {
        HideStartMenu();
        AudioManager.instance.KillAllAudio();
        AudioManager.instance.PlaySound(AudioManager.instance.sound_button);
        yield return new WaitForSeconds(1f);
        GameManager.instance.StartGame();
        yield return null;
    }
    private IEnumerator OnButtonTutorial_Coroutine()
    {
        HideStartMenu();
        AudioManager.instance.KillAllAudio();
        AudioManager.instance.PlaySound(AudioManager.instance.sound_button);
        yield return new WaitForSeconds(1f);
        GameManager.instance.StartGame();
        TutorialManager.instance.StartTutorial();
        yield return null;
    }
    private IEnumerator OnButtonExitLevel_Coroutine()
    {
        RhythmManager.instance.Exit();
        GameManager.instance.DestroyVotrex();
        AudioManager.instance.PlaySound(AudioManager.instance.sound_button);
        HidePlayerDeadMenu();
        yield return new WaitForSeconds(1f);
        WeaponManager.instance.FadeOutWeapons();
        HideGameHood();
        WorldsManager.instance.HideWorldsInScene();
        DeathManager.instance.DestroyDeathInScene();
        AudioManager.instance.KillAllAudio();
        ShowStartMenu();
        yield return new WaitForSeconds(1f);
        WeaponManager.instance.ClearWeaponPool();
        AudioManager.instance.PlaySound(AudioManager.instance.music_startMenu);
        ScoreManager.instance.ResetScore();
        yield return null;
    }
    private IEnumerator OnButtonRestart_Coroutine()
    {
        DeathManager.instance.ReviveDeathInScene();
        RhythmManager.instance.Restart();
        ScoreManager.instance.ResetScore();
        HidePlayerDeadMenu();
        AudioManager.instance.PlaySound(AudioManager.instance.sound_button);
        yield return null;
    }
    private IEnumerator OnButtonExitGame_Coroutine()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.sound_button);
        Application.Quit();
        yield return null;
    }

    public void ShowStartMenu()
    {
        startMenu.SetActive(true);
    }
    public void HideStartMenu()
    {
        if(startMenu.activeInHierarchy)
            startMenu.GetComponent<FadeInOut>().ForseFadeOut();
    }
    public void ShowPlayerDeadMenu()
    {
        playerDeadMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(resetButton);
    }
    public void HidePlayerDeadMenu()
    {
        if(playerDeadMenu.activeInHierarchy)
            playerDeadMenu.GetComponent<FadeInOut>().FadeOut();
    }
    public void ShowGameHood()
    {
        gameHood.SetActive(true);
    }
    public void HideGameHood()
    {
        gameHood.GetComponent<FadeInOut>().ForseFadeOut();
    }

    
}
