using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    public EnumData.World enemyType;
    public GameObject weaponToFrow;
    public GameObject catchedWeapon;
    public Animator animator;
    private bool isObjectCurent;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnEnable()
    {
        EnemyManager.instance.curentEnemyInScene = this;
    }
    
    public bool IsEnemyDead()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return false;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Frow"))
            return false;
        return true;
    }
    public void CallParentFadeOut()
    {
        if (transform.parent == null) return;
        transform.parent.GetComponent<World>().FadeOut();
    }
    public Weapon SpawnWeapon()
    {
        Weapon weapon = WeaponManager.instance.SpawnWeapon(weaponToFrow);
        return weapon;
    }

    private void Play_knight_death_byAxe()
    {
        GameObject sound = AudioManager.instance.sound_knight_death_byAxe;
        AudioManager.instance.PlaySound(sound);
    }
    private void Play_knight_death_bySpear()
    {
        GameObject sound = AudioManager.instance.sound_knight_death_bySpear;
        AudioManager.instance.PlaySound(sound);
    }
    private void Play_samurai_death_bySword()
    {
        GameObject sound = AudioManager.instance.sound_samurai_death_bySword;
        AudioManager.instance.PlaySound(sound);
    }
    private void Play_samurai_death_byAxe()
    {
        GameObject sound = AudioManager.instance.sound_samurai_death_byAxe;
        AudioManager.instance.PlaySound(sound);
    }
    private void Play_viking_death_bySword()
    {
        GameObject sound = AudioManager.instance.sound_viking_death_bySword;
        AudioManager.instance.PlaySound(sound);
    }
    private void Play_viking_death_bySpear()
    {
        GameObject sound = AudioManager.instance.sound_viking_death_bySpear;
        AudioManager.instance.PlaySound(sound);
    }


}
