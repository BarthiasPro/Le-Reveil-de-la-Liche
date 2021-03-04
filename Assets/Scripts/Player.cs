using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public int curHp;
    public int maxHp;
    public int damage;
    public float moveSpeed;
    public float interactRange;

    [Header("Items")]
    public List<string> inventory = new List<string>();



    [Header("Combat")]
    public KeyCode attackKey;
    public float attackRange;
    public bool isAttacking;
    public bool isTalking;
    public float attackRate;
    private float lastAttackTime;

    [Header("Experience")]
    public int curLevel;
    public int curXp;
    public int xpToNextLevel;
    public float levelXpModifier;

    // components
    private PlayerUI ui;
    private Rigidbody2D rig;
    private SpriteRenderer sr;
    [SerializeField]
    private ParticleSystem hitEffect;
    public Vector2 facingDirection;

    [Header("Animator")]
    public Animator animator;



    private void Awake()
    {
        // get the components
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        hitEffect = gameObject.GetComponentInChildren<ParticleSystem>();
        ui = FindObjectOfType<PlayerUI>();
    }

    private void Start()
    {
        maxHp = 10;
        curHp = maxHp;
        curXp = 0;
        xpToNextLevel = 10;
        // initialize UI elements
        ui.UpdateHealthBar();
        ui.UpdateXpBar();
        ui.UpdateLevelText();
        lastAttackTime = 0f;
        
    }

    private void Update()
    {
        if (!isTalking)
        {
            Move();
            Attack();
            CheckInteract();
        }
        else
        {
            Stop();
            if (Input.GetKeyDown(KeyCode.E))
            {
                ui.DisableDialog();
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }

    void CheckInteract()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facingDirection, interactRange, 1 << 9);

        if (hit.collider != null)
        {
            Interactable inter = hit.collider.GetComponent<Interactable>();
            ui.SetInteractText(hit.collider.transform.position, inter.interactDescription);
            if (Input.GetKeyDown(KeyCode.E))
            {
                inter.Interact();
            }
        }
        else
        {
            ui.DisableInteractText();
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(attackKey))
        {
            if (Time.time - lastAttackTime >= attackRate)
            {
                isAttacking = true;
                lastAttackTime = Time.time;
                animator.SetBool("attack", true);
                StartCoroutine(AttackCoolDown());
                RaycastHit2D hit = Physics2D.Raycast(transform.position, facingDirection, attackRange, 1 << 8);
                if (hit.collider != null)
                {         
                    hit.collider.GetComponent<Enemy>().takeDamage(damage);
                    hitEffect.transform.position = hit.collider.transform.position;
                    hitEffect.Play();                 
                }               
            }
        }        
    }

    private void Move()
    {        
        // get the horizontal and vertical keyboard inputs
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");



        Vector2 vel = new Vector2(x, y);

        if (vel.magnitude != 0)
        {
            facingDirection = vel;
        }

        UpdateSpriteDirection(x, y);

        rig.velocity = vel * moveSpeed;        
    }

    void UpdateSpriteDirection(float x, float y)
    {            
        animator.SetFloat("horizontal", x);
        animator.SetFloat("vertical", y);            
    }

    public void takeDamage(int damageTaken)
    {
        curHp -= damageTaken;               

        if (curHp <= 0)
        {
            Die();
        }
        ui.UpdateHealthBar();
    }

    void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScreen");
    }

    public void AddXp(int xp)
    {
        curXp += xp;

        if (curXp >= xpToNextLevel)
        {
            LevelUp();
        }
        ui.UpdateXpBar();
    }

    void LevelUp()
    {
        curXp -= xpToNextLevel;
        curLevel++;
        curHp += 2;
        maxHp += 2;
        damage += 1;

        xpToNextLevel = Mathf.RoundToInt((float)xpToNextLevel * levelXpModifier);
        if (curXp >= xpToNextLevel)
        {
            LevelUp();
        }
        else
        {
            ui.UpdateLevelText();
            ui.UpdateXpBar();
            ui.UpdateHealthBar();
        }
    }

    public void AddItemToInventory(string item)
    {
        inventory.Add(item);
        ui.UpdateInventoryText();
        if(item == "Sword")
        {
            animator.SetBool("weapon", true);
            damage += 10;
        }
    }

    public void RemoveItemFromInventory(string item)
    {
        inventory.Remove(item);
        ui.UpdateInventoryText();        
    }

    IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("attack", false);
        isAttacking = false;
    }

    public bool HasGold()
    {
        foreach(string i in inventory)
        { 
            if(i == "Gold coin")
            {
                return true;
            }
        }
        return false;        
    }

    public bool HasSword()
    {
        foreach (string i in inventory)
        {
            if (i == "Sword")
            {
                return true;
            }
        }
        return false;
    }

    public void stopTalk()
    {
        isTalking = false;
    }

    public void startTalk()
    {
        isTalking = true;
    }

    public int GetcurHP()
    {
        return curHp;
    }

    public int GetmaxHP()
    {
        return maxHp;
    }

    public void Stop()
    {
        UpdateSpriteDirection(0, 0);
        rig.velocity = new Vector2(0,0);
    }

    public void Heal()
    {
        curHp = maxHp;
        ui.UpdateHealthBar();
    }


}
