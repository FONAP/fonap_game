using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LettersManager : MonoBehaviour
{
    public Text totalLetters;
    public Text lettersCollected;
    private int totalLetterCount;
    private int counter;

    public GameObject canvasMessageSponsor;
    public bool gameIsPaused = false;
    bool verifyMessage = true;

    void Start()
    {
        totalLetterCount = transform.childCount;
        canvasMessageSponsor.SetActive(false);
    }

    void Update()
    {
        AllLettersCollected();
        totalLetters.text = totalLetterCount.ToString();
        counter = totalLetterCount - transform.childCount;
        lettersCollected.text = counter.ToString();

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
            }    
        }
    }

    public void AllLettersCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Todas las partes recogidas. VICTORIA!!");
        }
    }
}
