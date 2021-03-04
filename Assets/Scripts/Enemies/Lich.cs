using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : Enemy
{
    private void Start()
    {
        enemyID = 1;
        maxHp = 50;
        curHp = maxHp;
        damage = 1;
        moveSpeed = 2;
        xpToGive = 100;
        chaseRange = 3;
        attackRange = 1f;
        attackRate = 0.6f;
        lastAttackTime = 0;
    }
}
