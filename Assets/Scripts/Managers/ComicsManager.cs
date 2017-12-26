using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicsManager : MonoBehaviour
{
    public static ComicsManager instance;
    public Transform comicsSpawnPointEnemy;
    public Transform comicsSpawnPointDeath;
    public GameObject[] comics;

    public void Awake()
    {
        instance = this;
    }
    public void SpawnComicsAtEnemy()
    {
        int rand = (int)UnityEngine.Random.Range(0, 4f);
        if (rand == 4)
            rand = 3;
        var a = Instantiate(comics[rand]);
        a.transform.position = comicsSpawnPointEnemy.position;
        Destroy(a, 0.3f);
    }
    public void SpawnComicsAtDeath()
    {
        int rand = (int)UnityEngine.Random.Range(0, 4f);
        if (rand == 4)
            rand = 3;
        var a = Instantiate(comics[rand]);
        a.transform.position = comicsSpawnPointDeath.position;
        Destroy(a, 0.3f);
    }

}
