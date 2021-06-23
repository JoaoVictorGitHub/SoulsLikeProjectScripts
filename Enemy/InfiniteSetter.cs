using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteSetter : MonoBehaviour
{
    EnemyStats enemyStats;
    public bool infiniteCheck = false;
    public GameObject infiniteMenu;
    ScoreManager scoreManager;
    public int totalScore = 0;
    public Text puntuacionFinalText;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        enemyStats = GetComponent<EnemyStats>(); 
    }

    // Update is called once per frame
    public void Update()
    {
        if(enemyStats.isDead == true)
        {
            infiniteMenu.SetActive(true);
            infiniteCheck = true;
            ScoreInfiniteMenu();
        }
    }

    void ScoreInfiniteMenu()
    {
        int maximaPuntuacion = PlayerPrefs.GetInt("Score", 0);
        int puntuacionTotal = scoreManager.GetTotalScore();
        string puntuacionString = "Coin Bags Gathered = \n " + puntuacionTotal;



        if (maximaPuntuacion < puntuacionTotal)
        {
            puntuacionString += "\n New Highscore!";
            PlayerPrefs.SetInt("Score", puntuacionTotal);
            PlayerPrefs.Save();
        }

        puntuacionFinalText.text = puntuacionString;
    }
}
