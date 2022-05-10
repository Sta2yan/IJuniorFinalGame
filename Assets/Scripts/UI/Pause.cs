using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;

    private WaitForSeconds _second = new WaitForSeconds(1);

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void Close()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
