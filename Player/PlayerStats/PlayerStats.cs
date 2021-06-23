using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;

    public int maxStamina;
    public int currentStamina;
    public int staminaLevel = 10;

    HealthBar healthBar;
    StaminaBar staminaBar;

    AnimatorHandler animatorHandler;

    public GameObject player;

    public GameObject gameOver;

    public AudioSource hurtAudio;
    public AudioSource dieAudio;

    #region Singleton

    public static PlayerStats instance;

    Collider playerColl;

    ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        playerColl = GetComponent<Collider>();;
        instance = this;
        healthBar = FindObjectOfType<HealthBar>();
        staminaBar = FindObjectOfType<StaminaBar>();
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
    }
    #endregion

    void Start()
    {
        maxHealth = SetMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        maxStamina = SetMaxStaminaFromHealthLevel();
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
        player.layer = 10;
    }

    private int SetMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 100;
        return maxHealth;
    }

    private int SetMaxStaminaFromHealthLevel()
    {
        maxStamina = staminaLevel * 10;
        return maxStamina;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        healthBar.SetCurrentHealth(currentHealth);

        animatorHandler.PlayTargetAnimation("Damage_01", true);
        hurtAudio.Play();

        if (currentHealth <= 0)
        {
            dieAudio.Play();
            currentHealth = 0;
            animatorHandler.PlayTargetAnimation("Dead_01", true);
            //HANDLE PLAYER DEATH
            player.layer = 0;
            playerColl.enabled = false;
            gameOver.SetActive(true);
            scoreManager.AcabarJuego();
        }
    }

    public void TakeStaminaDamage(int damage)
    {
        currentStamina = currentStamina - damage;
        staminaBar.SetCurrentStamina(currentStamina);
    }
}
