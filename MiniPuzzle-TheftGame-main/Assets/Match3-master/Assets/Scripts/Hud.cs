using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Match3
{
    public class Hud : MonoBehaviour
    {
        public Level level;
        public GameOver gameOver;

        public Text remainingText;
        public Text remainingSubText;
        public Text targetText;
        public Text targetSubtext;
        public Text scoreText;
        public Image[] stars;

        private int _starIndex = 0;

        private void Start ()
        {
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].enabled = i == _starIndex;
            }
        }

        public void SetScore(int score)
        {
            scoreText.text = score.ToString();

            int visibleStar = 0;

            if (score >= level.score1Star && score < level.score2Star)
            {
                visibleStar = 1;
            }
            else if  (score >= level.score2Star && score < level.score3Star)
            {
                visibleStar = 2;
            }
            else if (score >= level.score3Star)
            {
                visibleStar = 3;
            }

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].enabled = (i == visibleStar);
            }

            _starIndex = visibleStar;
        }

        public void SetTarget(int target) => targetText.text = target.ToString();

        public void SetRemaining(int remaining) => remainingText.text = remaining.ToString();

        public void SetRemaining(string remaining) => remainingText.text = remaining;

        public void SetLevelType(LevelType type)
        {
            switch (type)
            {
                case LevelType.Moves:
                    remainingSubText.text = "Deneme Hakkı";
                    targetSubtext.text = "Kapının kilit zorlugu";
                    break;
                case LevelType.Obstacle:
                    remainingSubText.text = "Deneme Hakkı";
                    targetSubtext.text = "Kapının kilit zorlugu";
                    break;
                case LevelType.Timer:
                    remainingSubText.text = "zaman";
                    targetSubtext.text = "Kapının kilit zorlugu";
                    break;
            }
        }

        public void OnGameWin(int score)
        {
            gameOver.ShowWin(score, _starIndex);
            if (_starIndex > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, _starIndex);
            }
        }

        public void OnGameLose() => gameOver.ShowLose();
    }
}
