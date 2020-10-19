using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrozen : MonoBehaviour
{
    [SerializeField] Enemy AttachedEnemy;
    public void EnemyHit() {

        AttachedEnemy.EnemyFreeze();
    
    }
}
