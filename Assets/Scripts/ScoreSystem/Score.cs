using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ScoreSystem
{
    public class Score : MonoBehaviour
    {
        public TMP_Text gameOverScore;
        public TMP_Text score;
        public TMP_Text highscore;
        public float scorePoints;
        public float velocityMultiplier;
        float gop;

        void Start()
        {
            highscore.text = "Highscore: " + PlayerPrefs.GetFloat("Score").ToString("0");
        }

        void Update()
        {
            if (KillMenuSystem.Death.isDeath)
            {
                if (gop == 0) {gop = 1f;}
                if (gop <= scorePoints) {gop += Time.deltaTime * (scorePoints - gop) * velocityMultiplier;}
                if (gop > scorePoints) {gop = scorePoints;}
                gameOverScore.text = gop.ToString("0.00000");
            }

            else
            {
                score.text = scorePoints.ToString("0.00000");
            }

            if (scorePoints >= PlayerPrefs.GetFloat("Score"))
            {
                PlayerPrefs.SetFloat("Score", scorePoints);
            }

            if (!InMenu.i)
            {
                if (!KillMenuSystem.Death.isDeath)
                {
                    scorePoints += Time.deltaTime;
                }
            }
        }
    }
}