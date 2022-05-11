using UnityEngine;
using UnityEngine.Events;

public class GameStart : MonoBehaviour
{
    public event UnityAction Started;

    public void Play()
    {
        Started?.Invoke();
    }
}
