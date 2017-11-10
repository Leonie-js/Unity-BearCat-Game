using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    public Text text;

    void Awake ()
    {
        //score when starting game
        score = 0;
    }

    void Update ()
    {
        //change text when candy is eaten
        text.text = "Candy Found: " + score + "/10";
    }
}
