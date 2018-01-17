using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
    public GameObject vortex;
    public GameObject vortexInScene;

    private void Awake()
    {
        instance = this;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        AudioManager.instance.PlaySound(AudioManager.instance.music_startMenu);
    }

    public void StartGame()
    {
        StartCoroutine(StartGame_Coroutine());
    }
    private IEnumerator StartGame_Coroutine()
    {
        GameManager.instance.SpawnVortex();
        DeathManager.instance.CreateDeathInScene();
        yield return new WaitForSeconds(1f);
        GUIManager.instance.ShowGameHood();
        WorldsManager.instance.CreateEnemysInScene();
        WorldsManager.instance.EnableWorldInPool();
        RhythmManager.instance.StartRhythm();
        yield return null;
    }

    public void Exitlevel()
    {
        StartCoroutine(ExitLevel_Coroutine());
    }
    private IEnumerator ExitLevel_Coroutine()
    {
        RhythmManager.instance.Exit();
        GameManager.instance.DestroyVortex();
        //yield return new WaitForSeconds(1f);
        WeaponManager.instance.FadeOutWeapons();
        GUIManager.instance.HideGameHood();
        WeaponManager.instance.FadeOutWeapons();
        WorldsManager.instance.HideWorldsInScene();
        DeathManager.instance.DestroyDeathInScene();
        AudioManager.instance.KillAllAudio();
        yield return new WaitForSeconds(1f);
        WeaponManager.instance.ClearWeaponPool();
        ScoreManager.instance.ResetScore();
    }

    public void SpawnVortex()
    {
        vortexInScene = Instantiate(vortex);
    }
    public void DestroyVortex()
    {
        Destroy(vortexInScene);
    }

    
    
    
}
