using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FadeInOut))]
public class World : MonoBehaviour
{
    static public World lastEnabledWorld;

    public GameObject enemyChildPrefab;
    public Transform enemyChildSpawnPosition;
    private bool canFadeOutByFadeOutTimer;
    private float fadeOutTimer;
    private GameObject enemyChild;

    public List<Weapon> weaponsInWorld;

    public void Awake()
    {
        weaponsInWorld = new List<Weapon>();
    }
    public void OnEnable()
    {
        lastEnabledWorld = this;
        for (int i = 0; i < weaponsInWorld.Count; i++)
        {
            weaponsInWorld[i].GetComponent<FadeInOut>().ForseFadeIn();
        }
        if (this.enemyChild == null )
        {
            SpawnChildrenEnemy(this.enemyChildSpawnPosition);
        }
    }
    public void FadeOut()
    {
        GetComponent<FadeInOut>().ForseFadeOut();
        for (int i = 0; i < weaponsInWorld.Count; i++)
        {
            weaponsInWorld[i].GetComponent<FadeInOut>().ForseFadeOut();
        }
    }
    public void SpawnChildrenEnemy(Transform spawnPosition)
    {
        enemyChild = Instantiate(enemyChildPrefab);
        enemyChild.transform.parent = gameObject.transform;
        enemyChild.transform.position = spawnPosition.position;
    }
    public void Reset()
    {
        weaponsInWorld.Clear();
    }
}
