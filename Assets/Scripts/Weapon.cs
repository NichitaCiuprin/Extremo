using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public EnumData.World weaponType;
    public GameObject sparklePrefab;
    [HideInInspector]
    public Animator animator;
    public Transform sparkleSpawnPoint;
    public bool isDone;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnEnable()
    {

    }

    public void FlyRight()
    {
        animator.SetTrigger("FlyRight");
    }
    public void FlyLeft()
    {
        animator.SetTrigger("FlyLeft");
    }
    public void FlyUp()
    {
        animator.SetTrigger("FlyUp");
    }
    public void SpawnSparkle()
    {
        float x = sparkleSpawnPoint.position.x;
        float y = sparkleSpawnPoint.position.y;
        float z = -3;
        Vector3 newPosition = new Vector3(x, y, z);
        GameObject a = Instantiate(sparklePrefab);
        a.gameObject.transform.position = newPosition;
        AudioManager.instance.PlaySound(AudioManager.instance.sound_weaopn_collision);
    }
}
