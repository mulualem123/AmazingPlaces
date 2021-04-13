using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> UnansweredQues;
    private Question askedQues;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text resultText;

    [SerializeField]
    private float delayBetweenQuestions = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (UnansweredQues == null || UnansweredQues.Count == 0) {
            UnansweredQues = questions.ToList<Question>();
        }

        GetRandomQues();
    }

    void GetRandomQues()
    {
        int rQIndex = Random.Range(0, UnansweredQues.Count);
        askedQues = UnansweredQues[rQIndex];

        factText.text = askedQues.QuesPlace;

       
    }
    IEnumerator GotoNextQuestion() {
        UnansweredQues.Remove(askedQues);

        yield return new WaitForSeconds(delayBetweenQuestions);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SelectTrueButton()
    {
        if (askedQues.isTrue){
            resultText.text="Right";
        }
        else {
            resultText.text = "Wrong";
        }

        StartCoroutine(GotoNextQuestion());
    }

    public void SelectFalseButton()
    {
        if (!askedQues.isTrue){
            resultText.text = "Right";
        }
        else
        {
            resultText.text = "Wrong";
        }

        StartCoroutine(GotoNextQuestion());
    }

    public void BackToMain() {
        
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        
    }
    // Update is called once per frame
}
