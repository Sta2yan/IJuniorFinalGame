using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;
    [SerializeField] private float _disablePositionY;

    protected List<GameObject> Pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container);
            spawned.SetActive(false);
            Pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = Pool.FirstOrDefault(enemy => enemy.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        foreach (var item in Pool)
            if (item.activeSelf == true)
                if (item.transform.position.y > _disablePositionY)
                    item.SetActive(false);
    }

    public void ResetPool()
    {
        foreach (var item in Pool)
            item.SetActive(false);
    }
}
