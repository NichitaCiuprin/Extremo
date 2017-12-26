using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public Enemy curentEnemyInScene;
    public void OnEnable()
    {
        instance = this;
    }
}
