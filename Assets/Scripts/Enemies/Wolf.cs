using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy
{
    private void Start()
    {
        enemyID = 0;
        maxHp = 5;
        curHp = maxHp;
        damage = 1;
        moveSpeed = 4;
        xpToGive = 15;
        chaseRange = 3;
        attackRange = 1f;
        attackRate = 0.6f;
        lastAttackTime = 0;
    }
}
