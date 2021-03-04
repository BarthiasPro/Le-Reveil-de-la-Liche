using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Infos")]
    public int enemyID;

    [Header("Stats")]
    public int curHp;
    public int maxHp;
    public int damage;
    public float moveSpeed;
    public int xpToGive;

    [Header("Target")]
    public float chaseRange;

    [Header("Combat")]
    public float attackRange;
    public float attackRate;
    public float lastAttackTime;

    [Header("Animator")]
    public Animator animator;

    //components
    private Player player;
    private Rigidbody2D rig;
    public Transform fillImage;

    private void Awake()
    {        
        // get the player target
        player = FindObjectOfType<Player>();        
        // get the rigidoby component
        rig = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        float playerDist = Vector2.Distance(transform.position, player.transform.position);
        animator.SetFloat("range", playerDist);
        if(playerDist <= attackRange)
        {
            // attack the player
            if(Time.time - lastAttackTime >= attackRate )
            {
                Attack();
            }
            rig.velocity = Vector2.zero;

        }
        else if(playerDist <= chaseRange)
        {
            Chase();
        }
        else
        {
            rig.velocity = Vector2.zero;
        }
    }

    void Chase()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        float x = Mathf.Round(dir.x);
        float y = Mathf.Round(dir.y);
        UpdateSpriteDirection(x, y);
        rig.velocity = dir * moveSpeed;
    }

    void UpdateSpriteDirection(float x, float y)
    {

        animator.SetFloat("horizontal", x);
        animator.SetFloat("vertical", y);

    }

    public void takeDamage(int damageTaken)
    {
        curHp -= damageTaken;



        var newScale = this.fillImage.localScale;
        newScale.x = (float)curHp/maxHp;
        Debug.Log(curHp / maxHp);
        this.fillImage.localScale = newScale;

        if (curHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // give player xp
        EventController.EnemyDied(enemyID);
        player.AddXp(xpToGive);
        Destroy(gameObject);
    }

    void Attack()
    {
        lastAttackTime = Time.time;

        player.takeDamage(damage);
    }
}
