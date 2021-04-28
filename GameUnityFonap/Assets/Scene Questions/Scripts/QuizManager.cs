using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    public GameObject goTransition;

    int totalQuestions = 0;
    public int score;

    public string _returnToMenu;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void finish()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        goTransition.SetActive(true);
        Invoke("ChangeScene", 0.8f);
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void correct()
    {
        //when you are right
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(waitForNext());
    }

    public void wrong()
    {
        //when you answer wrong
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(waitForNext());
    }

    IEnumerator waitForNext()
    {
        yield return new WaitForSeconds(1);
        SceneManager.UnloadSceneAsync("SceneQuestions");
        // generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            
            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            switch (currentQuestion)
            {
                case 0:
                    if (Questions.doneQuestion0)
                    {
                        generateQuestion();
                        return;
                    }
                    Questions.doneQuestion0 = true;
                    break;
                case 1:
                    if (Questions.doneQuestion1)
                    {
                        generateQuestion();
                        return;
                    }
                    Questions.doneQuestion1 = true;
                    break;
                case 2:
                    if (Questions.doneQuestion2)
                    {
                        generateQuestion();
                        return;
                    }
                    Questions.doneQuestion2 = true;
                    break;
                case 3:
                    if (Questions.doneQuestion3)
                    {
                        generateQuestion();
                        return;
                    }
                    Questions.doneQuestion3 = true;
                    break;
                case 4:
                    if (Questions.doneQuestion4)
                    {
                        generateQuestion();
                        return;
                    }
                    Questions.doneQuestion4 = true;
                    break;
                case 5:
                    if (Questions.doneQuestion5)
                    {
                        generateQuestion();
                        return;
                    }
                    Questions.doneQuestion5 = true;
                    break;
            }

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            // GameOver();
        }
    }

    void ChangeScene()
        {
            SceneManager.LoadScene(_returnToMenu);
        }
}
