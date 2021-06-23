using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    ScoreManager scoreManager;
    AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioManager.coinDrop.Play();
            scoreManager.totalScore += scoreManager.scorePerTick;
            scoreManager.puntuacionGameplayText.text = scoreManager.totalScore.ToString();
            Destroy(this.gameObject);

        }
    }
}
