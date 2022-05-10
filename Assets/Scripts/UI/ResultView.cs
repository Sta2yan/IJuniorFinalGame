using UnityEngine;
using TMPro;

public class ResultView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lastScoreText;
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private Score _score;

    private void Start()
    {
        _lastScoreText.text = _score.LastScore.ToString();
        _bestScoreText.text = _score.BestScore.ToString();
    }
}
