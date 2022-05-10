using UnityEngine;

public class BonusRing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Spawner spawner = GetComponentInParent<Spawner>();
            spawner.TrySetSpeed();
        }
    }
}