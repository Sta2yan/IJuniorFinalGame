using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Score _score;
    [SerializeField] private float _timeChange;

    private void OnEnable()
    {
        _score.ScoreChanged += Render;
    }

    private void OnDisable()
    {
        _score.ScoreChanged -= Render;
    }

    private void Render()
    {
        _scoreText.DOText(_score.CurrentScore.ToString(), _timeChange, true, ScrambleMode.All);
    }
}
