using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> UnansweredQues;
    private Question askedQues;

    // Start is called before the first frame update
    void Start()
    {
        if (UnansweredQues == null || UnansweredQues.Count == 0) {
            UnansweredQues = questions.ToList<Question>();
        }

        GetRandomQues();
        Debug.Log (askedQues.QuesPlace + "is" + askedQues.isTrue);
    }

    void GetRandomQues()
    {
        int rQIndex = Random.Range(0, UnansweredQues.Count);
        askedQues = UnansweredQues[rQIndex];

        UnansweredQues.RemoveAt(rQIndex);
    }

    // Update is called once per frame
}
