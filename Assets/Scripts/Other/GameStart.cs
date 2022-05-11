using UnityEngine;
using UnityEngine.Events;

public class GameStart : MonoBehaviour
{
    public UnityAction Started;

    public void Play()
    {
        Started?.Invoke();
    }
}
