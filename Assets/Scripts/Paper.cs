using UnityEngine;

public class Paper : WarriorUnit, IUnit
{
    public TypeOfUnit GetTypeOfUnit() => TypeOfUnit.Paper;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IUnit unit))
            if (unit.GetTypeOfUnit() == TypeOfUnit.Scissors)
                Death(TypeOfUnit.Scissors);
            else
                TurnAround();
    }
}