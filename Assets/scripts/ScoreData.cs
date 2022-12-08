using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class ScoreData {
    public List<Score> scores;
    public List<string> names;
    public ScoreData()
    {
        scores = new List<Score>();
        names = new List<string>();
    }    

}

