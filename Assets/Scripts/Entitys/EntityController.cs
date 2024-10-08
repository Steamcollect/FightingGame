using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    public GameEvent Action(ActionType actionType, int value, EntityMotor target)
    {
        GameEvent currentAction;
        currentAction =  new GameEvent(actionType, value, target);

        switch (actionType)
        {
            case ActionType.Attack: OnAttack(); break;
            case ActionType.Shield: OnShield(); break;
            case ActionType.Heal: OnHeal(); break;
        }

        return currentAction;
    }

    public abstract void OnAttack();
    public abstract void OnHeal();
    public abstract void OnShield();
}