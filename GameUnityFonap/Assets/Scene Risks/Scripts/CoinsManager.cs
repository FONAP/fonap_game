using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinsManager : MonoBehaviour
{
    public Text totalCoins;
    public Text coinsCollected;
    private int totalCoinsCount;
    private int counter;

    public GameObject door;
    public GameObject finishGameView;
    public bool finishGame = false;

    private void Start()
    {
        totalCoinsCount = transform.childCount;
        //Debug.Log(totalCoinsCount + 1); ENTERO
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
        }

        if (finishGame == true)
        {
            finishGameView.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                finishGameView.SetActive(false);
            }
        }
    }

    public void AllCoinsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Todas las monedas recogidas. VICTORIA!!");
            door.SetActive(true);
            finishGame = true;
        }
    }
}
