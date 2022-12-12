using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class ScoreUi : MonoBehaviour
{
    public RowUi rowUi;
    public ScoreManager scoreManager;
    public Timer timer;
    private bool addedscore = false;
    public TextMeshProUGUI passRFail;

    // Start is called before the first frame update
    void Start()
    {
        //  scoreManager.AddScore(new Score(1000));
        // scoreManager.AddScore(new Score(9));
        // scoreManager.AddScore(new Score(2));
        // scoreManager.AddScore(new Score(32));
        var scores = scoreManager.GetHighScores().ToArray();
        var scoreboardLength = 5;
        if(scores.Length<5)
            scoreboardLength = scores.Length;
        for(int i=0; i < scoreboardLength;i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
            // row.rank.text = (i+1).ToString();
            row.name.text = scores[i].name;
            // row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString("0.00");
        }
            passRFail.text = "Your battery died! Now you wont make it to Brooklyn Bridge.";

    }

    // Update is called once per frame
    void Update()
    {
        if(timer.amountQuestions==20 && addedscore == false){
            if(timer.amountCorrect>=14){
                passRFail.text = "Well done! You have passed the mission with a time of : "+ timer.currentTime.ToString("0.00");
                scoreManager.AddScore(new Score(timer.currentTime, PersistentData.Instance.GetName()));
            }
            else
                passRFail.text = "You have failed!!! A score of 70% or over is required.";
            addedscore=true;

        }
        
    }
}
