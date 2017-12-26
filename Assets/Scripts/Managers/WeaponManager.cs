using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    private List<Weapon> weaponPool;

    public void Awake()
    {
        instance = this;
        weaponPool = new List<Weapon>();
    }
    public Weapon SpawnWeapon(GameObject weaponToSpawn)
    {
        GameObject obj = Instantiate(weaponToSpawn);
        Weapon weapon = obj.GetComponent<Weapon>();
        weaponPool.Add(weapon);
        return weapon;
    }
    public void DestroyWeapon(Weapon weaponToDestroy, float destroyDelay)
    {
        int weaponIndex = weaponPool.IndexOf(weaponToDestroy);
        weaponPool.RemoveAt(weaponIndex);
        Destroy(weaponToDestroy.gameObject, destroyDelay);
    }
    public void ClearWeaponPool()
    {
        for (int i = 0; i < weaponPool.Count; i++)
        {
            Destroy(weaponPool[i].gameObject);
        }
        weaponPool.Clear();
    }
    public void FadeOutWeapons()
    {
        for (int i = 0; i < weaponPool.Count; i++)
        {
            weaponPool[i].GetComponent<FadeInOut>().ForseFadeOut();
        }
    }
}
