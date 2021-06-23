using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    PlayerStats playerStats;
    HealthBar healthBar;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        healthBar = FindObjectOfType<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioManager.potionDrop.Play();
            playerStats.currentHealth = playerStats.maxHealth;
            healthBar.slider.value = healthBar.slider.maxValue;
            DestroyObj();
        }
    }

    void DestroyObj()
    {
        Destroy(this.gameObject);
    }

}
