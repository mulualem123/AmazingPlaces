using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> UnansweredQues;
    private Question askedQues;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text resultText;

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

        UnansweredQues.RemoveAt(rQIndex);
    }

    public void SelectTrueButton()
    {
        if (askedQues.isTrue){
            resultText.text="Right";
        }
        else {
            resultText.text = "Wrong";
        }
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
    }
    // Update is called once per frame
}
