using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldsManager : MonoBehaviour {

    public static WorldsManager instance;
    public GameObject[] prefabs_Worlds;
    private GameObject[] woldsInScene;
    private GameObject worldsPool;
    private bool isWorldWhereCreated;
    private GameObject lastEnabledWorld;

    private void Awake()
    {
        instance = this;
        isWorldWhereCreated = false;
    }

    public void EnableWorldInPool()
    {
        if (IsArrayEmpty(woldsInScene))
            return;
        if (IsArrayHasActiveGameObject(woldsInScene))
            return;
        SetActiveGameObjectInArray(woldsInScene);
    }
    public void HideWorldsInScene()
    {
        foreach (var world in woldsInScene)
        {
            if(world.gameObject.activeInHierarchy)
            {
                world.GetComponent<World>().Reset();
                world.GetComponent<FadeInOut>().ForseFadeOut();
            }
        }
    }
    public void CreateEnemysInScene()
    {
        if (isWorldWhereCreated) return;
        int amount = prefabs_Worlds.Length;
        woldsInScene = new GameObject[amount];
        this.worldsPool = new GameObject("WorldPool");
        for (int i = 0; i < prefabs_Worlds.Length; i++)
        {
            var newEnemy = Instantiate(prefabs_Worlds[i]);
            woldsInScene[i] = newEnemy;
            newEnemy.SetActive(false);
            newEnemy.transform.parent = worldsPool.transform;
        }
        isWorldWhereCreated = true;
    }
    
    private bool IsArrayEmpty(GameObject[] array)
    {
        foreach (GameObject item in array)
        {
            if (item != null) return false;
        }
        return true;
    }
    private bool IsArrayHasActiveGameObject(GameObject[] array)
    {
        foreach (GameObject item in array)
        {
            if (item.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }
    private void SetActiveGameObjectInArray(GameObject[] array)
    {
        int worldsAmount = array.Length;
        int randomIndex = UnityEngine.Random.Range(0, array.Length);
        if(lastEnabledWorld == null)
        {
            lastEnabledWorld = array[randomIndex];
            lastEnabledWorld.SetActive(true);
            return;
        }
        if(lastEnabledWorld.Equals(array[randomIndex]))
        {
            EnableWorldInPool();
        }
        else
        {
            lastEnabledWorld = array[randomIndex];
            lastEnabledWorld.SetActive(true);
        }
    }
}
