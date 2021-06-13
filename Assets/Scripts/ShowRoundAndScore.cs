using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRoundAndScore : MonoBehaviour
{
    public Text roundTextbox;
    public Text scoreTextbox;
    // Start is called before the first frame update
    void Start()
    {
        roundTextbox.text = "Round: " + PlayerPrefs.GetInt("round").ToString();
        scoreTextbox.text = "Score: " + PlayerPrefs.GetInt("score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
