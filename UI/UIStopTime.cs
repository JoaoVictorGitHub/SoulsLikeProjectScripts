using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStopTime : MonoBehaviour
{
    public bool isStoppingTime = false;
    public GameObject gameOptionsPanel;
    PlayerManager playerManager;
    PlayerLocomotion playerLocomotion;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        playerLocomotion = FindObjectOfType<PlayerLocomotion>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOptionsPanel.activeSelf )
        {
            if (playerManager.isInteracting == true)
                return;
            //gameOptionsPanel.SetActive(true);
            //stopTime = true;
            Time.timeScale = 0;
            rb.isKinematic = true;
            isStoppingTime = true;
            playerLocomotion.stepSound.Stop();

        }
        else
        {
            //gameOptionsPanel.SetActive(false);
            //stopTime = false;
            Time.timeScale = 1.0f;
            rb.isKinematic = false;
            isStoppingTime = false;

        }
    }
}
