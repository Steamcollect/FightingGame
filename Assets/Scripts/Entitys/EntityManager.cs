using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] List<EntityMotor> entitys;

    List<EntityAction> entitysActions;

    [Header("RSE")]
    [SerializeField] RSE_SendAction rse_SendActions;

    void SetTurn()
    {
        entitys = entitys.OrderBy(t => t.GetEntityPriority()).ToList();

        foreach (var entity in entitys)
        {
            entity.DoActions();
        }
    }

    public void AddEntityAction(EntityAction entityAction)
    {
        entitysActions.Add(entityAction);
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