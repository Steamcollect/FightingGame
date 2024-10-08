using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMotor : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] EntityData data;

    [Header("References")]
    [SerializeField] EntityController controller;

    EntityAction action;

    [Header("RSE")]
    [SerializeField] RSE_SendAction rse_SendAction;

    bool turnEnded;

    public void DoActions()
    {
        turnEnded = false;
        action.events.Clear();

        StartCoroutine(WaitUntilEndOfTurn());
    }

    IEnumerator WaitUntilEndOfTurn()
    {
        yield return new WaitUntil(() => turnEnded);

        rse_SendAction.Call(action);
    }

    public void Attack()
    {
        action.AddEvent(controller.Action(ActionType.Attack, data.attackDamage, this));
    }
    public void Shield()
    {
        action.AddEvent(controller.Action(ActionType.Shield, data.shieldPower, this));
    }
    public void Heal()
    {
        action.AddEvent(controller.Action(ActionType.Heal, data.healPower, this));
    }

    public void EndTurn()
    {
        turnEnded = true;
    }

    public int GetEntityPriority()
    {
        return data.priority;
    }
}