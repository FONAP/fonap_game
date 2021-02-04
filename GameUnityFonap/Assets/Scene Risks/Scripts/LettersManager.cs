using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LettersManager : MonoBehaviour
{
    public Text totalLetters;
    public Text lettersCollected;
    private int totalLetterCount;
    private int counter;

    public Text shadowTotalLetters;
    public Text shadowLettersCollected;

    public GameObject canvasMessageSponsor;
    public bool gameIsPaused = false;
    bool verifyMessage = true;

    public AudioSource clipOpenMagicBook;
    public AudioSource clipCloseMagicBook;

    public bool lettersIsComplete = false;
    public GameObject coinsManager;
    public bool coinsIsComplete;

    public GameObject transition;
    public GameObject canvasGeneral;

    void Start()
    {
        totalLetterCount = transform.childCount;
        canvasMessageSponsor.SetActive(false);
    }

    void Update()
    {
        coinsIsComplete = coinsManager.GetComponent<CoinsManager>().coinsIsComplete;
        AllLettersCollected();
        totalLetters.text = totalLetterCount.ToString();
        shadowTotalLetters.text = totalLetterCount.ToString();
        counter = totalLetterCount - transform.childCount;
        lettersCollected.text = counter.ToString();
        shadowLettersCollected.text = counter.ToString();

        if (!gameIsPaused)
        {
            switch (counter)
            {
                case 5:
                    if (verifyMessage)
                    {
                        canvasMessageSponsor.SetActive(true);
                        gameIsPaused = true;
                        verifyMessage = false;
                        clipOpenMagicBook.Play();
                    }
                    break;
            }
        }
        else if (gameIsPaused)
        {
            Time.timeScale = 0f;
            if (Input.GetKeyDown("x"))
            {
                canvasMessageSponsor.SetActive(false);
                Time.timeScale = 1f;
                gameIsPaused = false;
                clipCloseMagicBook.Play();
                if (lettersIsComplete && coinsIsComplete)
                {
                    canvasGeneral.SetActive(false);
                    transition.SetActive(true);
                    Invoke("ChangeScene", 1.1f);
                }
            }    
        }
    }

    public void AllLettersCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Todas las partes recogidas. VICTORIA!!");
            lettersIsComplete = true;
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
