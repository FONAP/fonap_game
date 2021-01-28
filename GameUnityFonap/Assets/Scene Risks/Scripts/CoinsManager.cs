using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CoinsManager : MonoBehaviour
{
    public Text totalCoins;
    public Text coinsCollected;
    private int totalCoinsCount;
    private int counter;

    public GameObject door;
    public GameObject finishGameView;
    public bool finishGame = false;

    public GameObject panelActivities;
    public GameObject activity1;
    public GameObject activity2;
    public GameObject activity3;
    public bool gameIsPaused = false;

    bool verifyActivity1 = true;
    bool verifyActivity2 = true;
    bool verifyActivity3 = true;

    public AudioSource clipOpenActivity;
    public AudioSource clipCloseActivity;

    private void Start()
    {
        totalCoinsCount = transform.childCount;
        panelActivities.SetActive(false);
    }

    private void Update()
    {
        if (finishGame == false)
        {
            AllCoinsCollected();
            totalCoins.text = totalCoinsCount.ToString();
            counter = totalCoinsCount - transform.childCount;
            coinsCollected.text = counter.ToString();
            // coinsCollected.text = transform.childCount.ToString(); CONTADOR DE MANERA INVERSA, QUITAR LA VARIABLE COUNTER

            if (!gameIsPaused)
            {
                switch (counter)
                {
                    case 5:
                        if (verifyActivity1)
                        {
                            panelActivities.SetActive(true);
                            activity1.SetActive(true);
                            gameIsPaused = true;
                            verifyActivity1 = false;
                            clipOpenActivity.Play();
                        }
                        break;
                    case 10:
                        if (verifyActivity2)
                        {
                            panelActivities.SetActive(true);
                            activity1.SetActive(false);
                            activity2.SetActive(true);
                            gameIsPaused = true;
                            verifyActivity2 = false;
                            clipOpenActivity.Play();
                        }
                        break;
                    case 15:
                        if (verifyActivity3)
                        {
                            panelActivities.SetActive(true);
                            activity2.SetActive(false);
                            activity3.SetActive(true);
                            gameIsPaused = true;
                            verifyActivity3 = false;
                            clipOpenActivity.Play();
                        }
                        break;
                }
            }
            else if (gameIsPaused)
            {
                Time.timeScale = 0f;
                if (Input.GetKeyDown("x"))
                {
                    panelActivities.SetActive(false);
                    Time.timeScale = 1f;
                    gameIsPaused = false;
                    clipCloseActivity.Play();
                }    
            }
        }

        /*
        if (finishGame == true)
        {
            finishGameView.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                finishGameView.SetActive(false);
            }
        }
        */
    }

    public void AllCoinsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Todas las monedas recogidas. VICTORIA!!");
            door.SetActive(true);
            // finishGame = true;
        }
    }
}
