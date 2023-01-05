using UnityEngine;

public class Scissors : WarriorUnit, IUnit
{
    public TypeOfUnit GetTypeOfUnit() => TypeOfUnit.Scissors;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IUnit unit))
            if (unit.GetTypeOfUnit() == TypeOfUnit.Rock)
                Death(TypeOfUnit.Rock);
            else
                TurnAround();
    }
}