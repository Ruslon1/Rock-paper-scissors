using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private List<WarriorUnit> _units;

    private Vector2 _minMaxX;
    private Vector2 _minMaxY;
    private int _totalCount;

    private void Start()
    {
        _minMaxX = new Vector2(-2.812505f, 2.812505f);
        _minMaxY = new Vector2(-5f, 5f);
    }

    public void SetCountOfUnits(String context)
    {
        _totalCount = int.Parse(context);
    }

    public void SpawnInitialUnits()
    {
        int countOfOneUnit = _totalCount / 3;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < countOfOneUnit; j++)
            {
                Vector3 position = new Vector3(Random.Range(_minMaxX.x, _minMaxX.y),
                    Random.Range(_minMaxY.x, _minMaxY.y));
                WarriorUnit unit = Instantiate(_units[i], position, Quaternion.identity);
                unit.MoveRandom();
            }
        }
    }

    public void Spawn(Transform targetTransform, TypeOfUnit enemy)
    {
        int indexOfUnit = (int)enemy;
        WarriorUnit unit = Instantiate(_units[indexOfUnit], targetTransform);
        unit.MoveRandom();
    }
}