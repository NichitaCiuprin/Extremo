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
    public void SpawnVortex()
    {
        vortexInScene = Instantiate(vortex);
    }
    public void DestroyVotrex()
    {
        Destroy(vortexInScene);
    }

    public IEnumerator StartGame_Coroutine()
    {
        GameManager.instance.SpawnVortex();
        DeathManager.instance.CreateDeathInScene();
        yield return new WaitForSeconds(1f);
        UIManager.instance.ShowGameHood();
        WorldsManager.instance.CreateEnemysInScene();
        WorldsManager.instance.EnableWorldInPool();
        RhythmManager.instance.StartRhythm();
        yield return null;
    }

    
    
}
