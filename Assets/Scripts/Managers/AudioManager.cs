using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public bool isKillVolume;
    private List<GameObject> soundsInScene;
    public GameObject sound_death_death;
    public GameObject sound_death_deflect;
    public GameObject sound_death_tierd;
    public GameObject sound_knight_death_byAxe;
    public GameObject sound_knight_death_bySpear;
    public GameObject sound_viking_death_bySword;
    public GameObject sound_viking_death_bySpear;
    public GameObject sound_samurai_death_bySword;
    public GameObject sound_samurai_death_byAxe;
    public GameObject sound_weaopn_collision;
    public GameObject sound_button;

    [HideInInspector]
    public GameObject musicInScene;
    public GameObject music_startMenu;
    public GameObject music_level;
    
    private void Awake()
    {
        instance = this;
        soundsInScene = new List<GameObject>();
    }

    public GameObject PlaySound(GameObject soundToPlay)
    {
        GameObject newSound = Instantiate(soundToPlay);
        newSound.GetComponent<AudioSource>().Play();
        if (isKillVolume)
            newSound.GetComponent<AudioSource>().volume = 0;
        newSound.transform.parent = this.transform;
        this.soundsInScene.Add(newSound);
        return newSound;
    }
    public void PlayMusic(GameObject musicToPlay)
    {
        Destroy(this.musicInScene);
        this.musicInScene = Instantiate(musicToPlay);
        this.musicInScene.GetComponent<AudioSource>().Play();
        if (this.isKillVolume)
            this.musicInScene.GetComponent<AudioSource>().volume = 0;
        this.musicInScene.transform.parent = this.transform;
    }
    public void StopSound(GameObject soundToStop)
    {
        if (!soundsInScene.Contains(soundToStop)) return;
        Destroy(soundToStop);
    }
    public void KillAllAudio()
    {
        for (int i = 0; i < soundsInScene.Count; i++)
        {
            Destroy(soundsInScene[i].gameObject);
        }
        Destroy(musicInScene);
    }
}



