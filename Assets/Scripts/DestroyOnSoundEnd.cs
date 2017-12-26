using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnSoundEnd : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartCoroutine(DestroySoundOnEnd());
    }

    private IEnumerator DestroySoundOnEnd()
    {
        yield return new WaitForEndOfFrame();
        while(audioSource.isPlaying)
        {
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
