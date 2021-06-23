using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;

    Animator animator;

    EnemySimple enemySimple;

    InputHandler inputHandler;

    public GameObject[] loot;
    public GameObject selector;
    public int numSelectors = 5;
    public bool isDead = false;

    InfiniteEnemies infiniteEnemies;
    public AudioSource enemyHurtSound;
    CameraHandler cameraHandler;
    Collider thisCollider;

    private void Awake()
    {
        thisCollider = GetComponent<Collider>();
        cameraHandler = FindObjectOfType<CameraHandler>();
        infiniteEnemies = FindObjectOfType<InfiniteEnemies>();
        animator = GetComponent<Animator>();
        enemySimple = GetComponent<EnemySimple>();
        inputHandler = FindObjectOfType<InputHandler>();
    }

    private void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0 && inputHandler.lockOnFlag == false)
        {
            Invoke("DestroyEnemy", 6.0f);
        }
        if (isDead == true)
        {
            DropLoot();
        }

    }

    private void LateUpdate()
    {
        isDead = false;
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    public void TakeDamage(int damage)
    {

        currentHealth = currentHealth - damage;

        animator.SetTrigger("Damage");
        enemyHurtSound.pitch = Random.Range(0.8f, 1f);
        enemyHurtSound.Play();

        if (currentHealth <= 0 )
        {
            currentHealth = 0;
            animator.SetBool("Dead", true);
            //HANDLE ENEMY DEATH
            enemySimple.enabled = false;
            isDead = true;
            thisCollider.enabled = false;
            inputHandler.lockOnFlag = false;
            inputHandler.lockOnInput = false;
            cameraHandler.ClearLockOnTarget();
        }
    }

    void DropLoot()
    {
        if(loot != null)
        {
            loot = new GameObject[numSelectors];
            for (int i = 0; i < numSelectors; i++)
            {
                GameObject go = Instantiate(selector, transform.position, transform.rotation) as GameObject;
                loot[i] = go;
            }
        }

    }
    
    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
