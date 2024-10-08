using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] List<EntityMotor> entitys;

    List<EntityAction> entitysActions;

    [Header("RSE")]
    [SerializeField] RSE_SendAction rse_SendActions;

    void GetAllActions()
    {
        foreach (var entity in entitys)
        {
            entity.DoActions();
        }
    }

    void UseAction()
    {
        entitysActions = entitysActions.OrderBy(t => t.entity.GetEntityPriority()).ToList();
    }

    public void AddEntityAction(EntityAction entityAction)
    {
        entitysActions.Add(entityAction);

        if(entitysActions.Count >=  entitys.Count) 
        {
            UseAction();
        }
    }

    private void OnEnable()
    {
        rse_SendActions.action += AddEntityAction;
    }
    private void OnDisable()
    {
        rse_SendActions.action -= AddEntityAction;
    }
}