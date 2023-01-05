using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class WarriorUnit : MonoBehaviour, IDeathable
{
    [SerializeField] private UnitMover _mover;
    
    private UnitSpawner _spawner;
    private TypeOfUnit _enemy;

    private void Start()
    {
        _spawner = FindObjectOfType<UnitSpawner>();
    }

    public void Death(TypeOfUnit killer)
    {
        _enemy = killer;
        Destroy(gameObject);
    }
    
    public void MoveRandom() => _mover.MoveRandomDirection();

    protected void TurnAround()
    {
        _mover.MoveOpposite();
    }

    private void OnDestroy()
    {
        _spawner.Spawn(transform, _enemy);
    }
}

public interface IDeathable
{
    void Death(TypeOfUnit killer);
}

public interface IUnit
{
    TypeOfUnit GetTypeOfUnit();
}

public interface IMover
{
    void MoveRandomDirection();
    void MoveOpposite();
}

public enum TypeOfUnit
{
    Scissors, Paper, Rock
}