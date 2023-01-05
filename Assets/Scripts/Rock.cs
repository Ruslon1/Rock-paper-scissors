using UnityEngine;

public class Rock : WarriorUnit,IUnit
{
    public TypeOfUnit GetTypeOfUnit() => TypeOfUnit.Rock;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IUnit unit))
            if (unit.GetTypeOfUnit() == TypeOfUnit.Paper)
                Death(TypeOfUnit.Paper);
            else
                TurnAround();
    }
}