using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
    void Start()
    {
       scoreText.text ="SCORE :"+ score;
    }
        
    public void RemoveScore(int amount)
    {
        score -= amount;

        if (score < 0)
        {
            score =0;
        }
        scoreText.text = "SCORE :"+ score;
    }

    public void AddScore(int amount)
    {
        score += amount;// update the scoring
        scoreText.text = "SCORE :" + score;
        if(score>=110)
            {
                scoreText.text = "You ended the intergalactic Threat";
            }
    }
    
}
