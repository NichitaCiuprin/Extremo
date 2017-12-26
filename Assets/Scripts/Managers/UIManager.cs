using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;
    public GameObject playerDeadMenu;
    public GameObject gameHood;

    private FadeInOut startMenuFadeInOut;

    public void Awake()
    {
        instance = this;
        startMenuFadeInOut = startMenu.GetComponent<FadeInOut>();
    }
    public void Start()
    {
        ShowStartMenu();
        HidePlayerDeadMenu();
    }

    public void OnButtonStartGame()
    {
        StartCoroutine(StartGame_Coroutine());
    }
    public void OnButtonTutorial()
    {
        StartCoroutine(StartGame_Coroutine());
        TutorialManager.instance.StartTutorial();
    }
    public void OnButtonExitLevel()
    {
        StartCoroutine(Exit_Coroutine());
    }
    public void OnButtonRestart()
    {
        DeathManager.instance.ReviveDeathInScene();
        RhythmManager.instance.Restart();
        ScoreManager.instance.ResetScore();
        HidePlayerDeadMenu();
        AudioManager.instance.PlaySound(AudioManager.instance.sound_button);
    }
    public void OnButtonExitGame()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.sound_button);
        Application.Quit();
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

    private IEnumerator StartGame_Coroutine()
    {
        HideStartMenu();
        GameManager.instance.SpawnVortex();
        AudioManager.instance.KillAllAudio();
        AudioManager.instance.PlaySound(AudioManager.instance.sound_button);
        DeathManager.instance.CreateDeathInScene();
        yield return new WaitForSeconds(1f);
        ShowGameHood();
        WorldsManager.instance.CreateEnemysInScene();
        WorldsManager.instance.EnableWorldInPool();
        RhythmManager.instance.StartRhythm();
    }
    private IEnumerator Exit_Coroutine()
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
    }
}
