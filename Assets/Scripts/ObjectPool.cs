using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _cointainer;
    [SerializeField] private int _capacity;

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _cointainer.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    { 
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(-1.5f,0));

        foreach (GameObject obj in _pool) 
        {
            if (obj.activeSelf == true)
            {
                if (obj.transform.position.x < disablePoint.x)
                {
                    obj.SetActive(false);
                }
            }
        }
    }

    public void ResetPool()
    {
        foreach (var pool in _pool)
        { 
            pool.SetActive(false);
        }
    }
}
