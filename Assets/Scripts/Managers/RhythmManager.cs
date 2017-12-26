using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    //int 1 = 0.01s
    //enemy idle 1s
    //enemy frow 0.5s 
    //weapon fly 1s
    //weapon flyUp 2s
    public static RhythmManager instance;
    public enum State
    {
        play = 0,
        stop = 1
    }
    [HideInInspector]
    public State state = State.play;
    public bool isEnableDebugGUI;
    public const int fixedDeltaTime = 2;
    private int metronom = -2; //50
    private int enemyRandomFrowTimer = -2; 
    private int enemyFrowTime = -2;
    private int enemyDeathTime = -2;
    private int worldFadeInTime = -2;
    private int worldFadeOutTimer = -2;
    private int worldFadeOutTime = -2;
    private List<int> weaponCollideDeathTimers = new List<int>();
    private List<Weapon> weaponCollideDeath = new List<Weapon>();
    private List<int> weaponCollideEnemyTimers = new List<int>();
    private List<Weapon> weaponCollideEnemy = new List<Weapon>();
    private bool isRestart;
    private bool isPlayLevelMusic;

    private void OnGUI()
    {
        if (!isEnableDebugGUI) return;
        Rect rect = new Rect(0, 0, 50, 100);
        string colorGreen = "00ff00ff";
        GUIStyle gUIStyle = new GUIStyle();
        gUIStyle.fontSize = 50;
        GUI.TextField(rect, Utilities.ChangeStringColor("Metronom " + metronom.ToString(), colorGreen), gUIStyle);
        rect.y += 50;
        GUI.TextField(rect, Utilities.ChangeStringColor("EnemyRandomFrowTimer " + enemyRandomFrowTimer.ToString(), "ff0000ff"), gUIStyle);
        rect.y += 50;
        GUI.TextField(rect, Utilities.ChangeStringColor("EnemyFrowTime " + enemyFrowTime.ToString(), "ff0000ff"), gUIStyle);
        rect.y += 50;
        GUI.TextField(rect, Utilities.ChangeStringColor("EnemyDeathTime " + enemyDeathTime.ToString(), "ff0000ff"), gUIStyle);
        rect.y += 50;
        GUI.TextField(rect, Utilities.ChangeStringColor("WorldFadeInTimer " + worldFadeInTime.ToString(), "00ffffff"), gUIStyle);
        rect.y += 50;
        GUI.TextField(rect, Utilities.ChangeStringColor("WorldFadeOutTimer " + worldFadeOutTimer.ToString(), "00ffffff"), gUIStyle);
        rect.y += 50;
        GUI.TextField(rect, Utilities.ChangeStringColor("WorldFadeOutTime " + worldFadeOutTime.ToString(), "00ffffff"), gUIStyle);
        rect.y += 50;
        rect.x += 50;
        for (int i = 0; i < weaponCollideDeathTimers.Count; i++)
        {
            GUI.TextField(rect, Utilities.ChangeStringColor("WeaponCollideDeathTimer " + weaponCollideDeathTimers[i].ToString(), "ffff00ff"), gUIStyle);
            rect.y += 50;
        }
        for (int i = 0; i < weaponCollideEnemyTimers.Count; i++)
        {
            GUI.TextField(rect, Utilities.ChangeStringColor("WeaponCollideEnemyTimer " + weaponCollideEnemyTimers[i].ToString(), "ffff00ff"), gUIStyle);
            rect.y += 50;
        }
    }
    private void Awake()
    {
        instance = this;
        state = State.play;
        isRestart = false;
        isPlayLevelMusic = true;
    }
    private void FixedUpdate()
    {
        UpdateAllTimers();
        ManageTimersEvents();
    }

    public void StartRhythm()
    {
        state = State.play;
        worldFadeInTime = 100;
        metronom = 50;
    }
    public void Stop()
    {
        state = State.stop;
        worldFadeOutTimer = -2;
        enemyRandomFrowTimer = -2;
    }
    public void Restart()
    {
        isRestart = true;
    }
    public void Exit()
    {
        Stop();
        metronom = -2;
        AudioManager.instance.KillAllAudio();
        isPlayLevelMusic = true;
    }

    private void UpdateAllTimers()
    {
        if(metronom >= 0)
            metronom -= fixedDeltaTime;
        if (enemyRandomFrowTimer >= 0)
            enemyRandomFrowTimer -= fixedDeltaTime;
        if (enemyFrowTime >= 0)
            enemyFrowTime -= fixedDeltaTime;
        if (enemyDeathTime >= 0)
            enemyDeathTime -= fixedDeltaTime;
        if (worldFadeInTime >= 0)
            worldFadeInTime -= fixedDeltaTime;
        if (worldFadeOutTimer >= 0)
            worldFadeOutTimer -= fixedDeltaTime;
        if (worldFadeOutTime >= 0)
            worldFadeOutTime -= fixedDeltaTime;
        for (int i = 0; i < weaponCollideDeathTimers.Count; i++)
        {
            if (weaponCollideDeathTimers[i] >= 0)
                weaponCollideDeathTimers[i] -= fixedDeltaTime;
        }
        for (int i = 0; i < weaponCollideEnemyTimers.Count; i++)
        {
            if (weaponCollideEnemyTimers[i] >= 0)
                weaponCollideEnemyTimers[i] -= fixedDeltaTime;
        }
    }
    private void ManageTimersEvents()
    {
        MetronomEvents();
        WeaponTimersEvents();
        EnemyTimersEvents();
        WorldTimersEvents();
    }
    private void MetronomEvents()
    {
        if (metronom == 0)
        {
            this.metronom = 50;
            if(this.isRestart)
            {
                this.state = State.play;
                this.worldFadeOutTimer = 800;
                this.enemyRandomFrowTimer = 150;
                this.isRestart = false;
            }
            if (this.isPlayLevelMusic)
            {
                this.isPlayLevelMusic = false;
                if (AudioManager.instance.musicInScene == null)
                    AudioManager.instance.PlayMusic(AudioManager.instance.music_level);
            }
        }
    }
    private void WorldTimersEvents()
    {
        if (worldFadeInTime == 0)
        {
            if (state == State.play)
            {
                enemyRandomFrowTimer = 150;
                worldFadeOutTimer = 800;
            }
            else
            {
                enemyRandomFrowTimer = -2;
                worldFadeOutTimer = -2;
            }
        }
        if (worldFadeOutTimer == 0)
        {
            enemyRandomFrowTimer = -2;
            worldFadeOutTime = 100;
            World.lastEnabledWorld.FadeOut();
        }
        //if (worldFadeOutTimer == 50)
        //{
        //    weaponCollideEnemyTimers.Add(100);
        //    Weapon weapon = EnemyManager.instance.curentEnemyInScene.SpawnWeapon();
        //    weapon.weaponType = EnumData.World.Knight;
        //    weaponCollideEnemy.Add(weapon);
        //}
        if (worldFadeOutTime == 0)
        {
            World.lastEnabledWorld.gameObject.SetActive(false);
            WorldsManager.instance.EnableWorldInPool();
            worldFadeInTime = 100;
        }
    }
    private void WeaponTimersEvents()
    {
        WeaponCollideDeathEvents();
        WeaponCollideEnemyEvents();
    }
    private void EnemyTimersEvents()
    {
        if (enemyDeathTime == 0)
        {
            EnemyManager.instance.curentEnemyInScene.CallParentFadeOut();
            worldFadeOutTime = 100;
        }
        if (enemyFrowTime == 0)
        {
            weaponCollideDeathTimers.Add(100);
            Weapon weapon = EnemyManager.instance.curentEnemyInScene.SpawnWeapon();
            weaponCollideDeath.Add(weapon);
        }
        if (enemyRandomFrowTimer == 0)
        {
            enemyRandomFrowTimer = 150;
            if (!EnemyManager.instance.curentEnemyInScene.isActiveAndEnabled) return;
            EnemyManager.instance.curentEnemyInScene.animator.SetTrigger("FrowWeapon");
            enemyFrowTime = 50;
        }
    }
    private void WeaponCollideEnemyEvents()
    {
        for (int i = 0; i < weaponCollideEnemyTimers.Count; i++)
        {
            if (weaponCollideEnemyTimers[i] == 0)
            {
                bool isCollideEnemy = !EnemyManager.instance.curentEnemyInScene.IsEnemyDead() && worldFadeOutTime == -2 && worldFadeInTime == -2;
                if (isCollideEnemy)
                {
                    if (weaponCollideEnemy[i].weaponType == EnemyManager.instance.curentEnemyInScene.enemyType)
                    {
                        EnemyManager.instance.curentEnemyInScene.animator.SetTrigger("FrowWeapon");
                        enemyRandomFrowTimer = 150;
                        enemyFrowTime = 50;
                    }
                    else
                    {
                        ComicsManager.instance.SpawnComicsAtEnemy();
                        ScoreManager.instance.IncrementScore();
                        EnemyManager.instance.curentEnemyInScene.animator.SetTrigger("Die");
                        EnemyManager.instance.curentEnemyInScene.animator.SetInteger("DeathType", (int)weaponCollideEnemy[i].weaponType);
                        enemyRandomFrowTimer = -2;
                        enemyDeathTime = 50;
                        worldFadeOutTimer = -2;
                        enemyFrowTime = -2;
                    }
                    WeaponManager.instance.DestroyWeapon(weaponCollideEnemy[i], 0f);
                    weaponCollideEnemyTimers.RemoveAt(i);
                    weaponCollideEnemy.RemoveAt(i);
                    --i;
                }
                else
                {
                    World.lastEnabledWorld.weaponsInWorld.Add(weaponCollideEnemy[i]);
                    weaponCollideEnemyTimers.RemoveAt(i);
                    weaponCollideEnemy.RemoveAt(i);
                    --i;
                }
            }
        }
    }
    private void WeaponCollideDeathEvents()
    {
        List<int> colidedWeaponIndexes = WeaponsCollideDeathTimerOut();
        List<int> weaponsToRemoveIndexes = new List<int>();
        for (int i = 0; i < colidedWeaponIndexes.Count; i++)
        {
            int weaponIndex = colidedWeaponIndexes[i];
            Death deathInScene = DeathManager.instance.deathInScene;
            bool isGoFroughtDeath = !deathInScene.gameObject.activeInHierarchy || deathInScene.state == Death.State.dead;
            if (isGoFroughtDeath)
            {
                WeaponFlyThroughtDeath(weaponsToRemoveIndexes, weaponIndex);
            }
            else
            {
                WeaponFlyToDeath(colidedWeaponIndexes.Count, weaponIndex, weaponsToRemoveIndexes);
            }
        }
        RemoveWeaponsCollideDeath(weaponsToRemoveIndexes);
    }
    private List<int> WeaponsCollideDeathTimerOut()
    {
        List<int> collidedWeaponIndexes = new List<int>();
        for (int i = 0; i < this.weaponCollideDeathTimers.Count; i++)
        {
            if (this.weaponCollideDeathTimers[i] == 0)
            {
                collidedWeaponIndexes.Add(i);
            }
        }
        return collidedWeaponIndexes;
    }
    private void WeaponFlyThroughtDeath(List<int> weaponsToRemoveIndexes, int weaponIndex)
    {
        if (weaponCollideDeath[weaponIndex].animator.GetCurrentAnimatorStateInfo(0).IsName("FlyUp"))
        {
            weaponCollideDeath[weaponIndex].animator.SetTrigger("FlyUpEnd");
        }
        else if (weaponCollideDeath[weaponIndex].animator.GetCurrentAnimatorStateInfo(0).IsName("FlyRight"))
        {
            weaponCollideDeath[weaponIndex].animator.SetTrigger("FlyRightEnd");
        }
        else
        {
            Debug.LogError("Weapon animator state name not found");
        }
        World.lastEnabledWorld.weaponsInWorld.Add(weaponCollideDeath[weaponIndex]);
        weaponsToRemoveIndexes.Add(weaponIndex);
    }
    private void WeaponFlyToDeath(int weaponAmount, int weaponIndex, List<int> weaponsToRemoveIndexes)
    {
        switch (weaponAmount)
        {
            case 1:
                WeaponCheckDeathState(weaponsToRemoveIndexes, weaponIndex);
                break;
            case 2:
                if (weaponCollideDeath[weaponIndex].animator.GetCurrentAnimatorStateInfo(0).IsName("FlyRight"))
                {
                    WeaponManager.instance.DestroyWeapon(weaponCollideDeath[weaponIndex], 0f);
                    weaponCollideDeath[weaponIndex].animator.SetTrigger("Break");
                    weaponsToRemoveIndexes.Add(weaponIndex);
                }
                else
                {
                    WeaponCheckDeathState(weaponsToRemoveIndexes, weaponIndex);
                }
                break;
        }
    }
    private void WeaponCheckDeathState(List<int> weaponsToRemoveIndexes, int weaponIndex)
    {
        Death deathInScene = DeathManager.instance.deathInScene;
        switch (deathInScene.state)
        {
            case Death.State.idle:
                MakeWeaponKillDeath(weaponsToRemoveIndexes, weaponIndex);
                break;
            case Death.State.tierd:
                MakeWeaponKillDeath(weaponsToRemoveIndexes, weaponIndex);
                break;
            case Death.State.deflect:
                deathInScene.Idle();
                this.weaponCollideDeath[weaponIndex].SpawnSparkle();
                switch (deathInScene.deflectDirection)
                {
                    case Death.DeflectDirection.left:
                        this.weaponCollideDeath[weaponIndex].animator.SetTrigger("FlyLeft");
                        this.weaponCollideEnemyTimers.Add(100);
                        this.weaponCollideEnemy.Add(weaponCollideDeath[weaponIndex]);
                        weaponsToRemoveIndexes.Add(weaponIndex);
                        break;
                    case Death.DeflectDirection.right:
                        WeaponManager.instance.DestroyWeapon(weaponCollideDeath[weaponIndex],1f);
                        this.weaponCollideDeath[weaponIndex].animator.SetTrigger("FlyRight");
                        weaponsToRemoveIndexes.Add(weaponIndex);
                        break;
                    case Death.DeflectDirection.up:
                        this.weaponCollideDeathTimers[weaponIndex] = 200;
                        weaponCollideDeath[weaponIndex].animator.SetTrigger("FlyUp");
                        break;
                }
                break;
        }
    }
    private void RemoveWeaponsCollideDeath(List<int> weaponsToDeleteIndexes)
    {
        for (int i = weaponsToDeleteIndexes.Count - 1; i != -1; i--)
        {
            int j = weaponsToDeleteIndexes[i];
            this.weaponCollideDeathTimers.RemoveAt(j);
            this.weaponCollideDeath.RemoveAt(j);
        }
    }
    private void MakeWeaponKillDeath(List<int> weaponsToDeleteIndexes, int weaponIndex)
    {
        ComicsManager.instance.SpawnComicsAtDeath();
        Death deathInScene = DeathManager.instance.deathInScene;
        deathInScene.Die();
        deathInScene    .state = Death.State.dead;
        weaponCollideDeath[weaponIndex].animator.SetTrigger("KillDeath");
        weaponsToDeleteIndexes.Add(weaponIndex);
        RhythmManager.instance.Stop();
        StartCoroutine(ShowRestartUI());
    }
    private IEnumerator ShowRestartUI()
    {
        yield return new WaitForSeconds(1f);
        if (UIManager.instance != null)
        {
            UIManager.instance.ShowPlayerDeadMenu();
        }
    }
}
