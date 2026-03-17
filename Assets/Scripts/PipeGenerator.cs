using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondBetweenSpawn;
    [SerializeField] private float _maxSpawnPosinionY;
    [SerializeField] private float _minSpawnPosinionY;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondBetweenSpawn)
        {
            if (TryGetObject(out GameObject pipe))
            {
                _elapsedTime = 0;

                float spawnPosY = Random.Range(_minSpawnPosinionY, _maxSpawnPosinionY);
                Vector3 spawnPos = new Vector3(transform.position.x, spawnPosY, transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPos;

                DisableObjectAbroadScreen();
            }
        }
    }

}
