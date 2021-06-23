using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighscore : MonoBehaviour
{
    public Text maximaPuntuacionText;

    private void Start()
    {
        int maximaPuntuacion = PlayerPrefs.GetInt("Score", 0);
        string maximaPuntuacionString = "Highscore \n " + maximaPuntuacion;
        maximaPuntuacionText.text = maximaPuntuacionString;

    }
}
