using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public static DeathManager instance;

    public GameObject death_Prefab;
    [HideInInspector]
    public Death deathInScene;

    public void Awake()
    {
        instance = this;
    }

    public void CreateDeathInScene()
    {
        if(deathInScene != null)
        {
            deathInScene.gameObject.SetActive(true);
        }
        deathInScene = Instantiate(death_Prefab).GetComponent<Death>();
    }
    public void DestroyDeathInScene()
    {
        Destroy(deathInScene.gameObject);
    }
    public void ReviveDeathInScene()
    {
        deathInScene.gameObject.SetActive(true);
    }

    
    
    
    
}
