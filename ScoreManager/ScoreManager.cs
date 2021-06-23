using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public bool juegoAcabado = false;
    MoneyCounter moneyCounter;
    public Text puntuacionFinalText, puntuacionGameplayText;
    public int totalScore = 0;
    public int scorePerTick = 1;


    // Start is called before the first frame update
    void Start()
    {
        moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AcabarJuego()
    {
        juegoAcabado = true;

        int maximaPuntuacion = PlayerPrefs.GetInt("Score", 0);
        int puntuacionTotal = GetTotalScore();
        string puntuacionString = "Coin Bags Gathered = \n " + puntuacionTotal;



        if (maximaPuntuacion < puntuacionTotal)
        {
            puntuacionString += "\n New Highscore!";
            PlayerPrefs.SetInt("Score", puntuacionTotal);
            PlayerPrefs.Save();
        }

        puntuacionFinalText.text = puntuacionString;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }
}
