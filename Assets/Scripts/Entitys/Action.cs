using System.Collections.Generic;

[System.Serializable]
public class EntityAction
{
    public EntityMotor entity;

    public List<GameEvent> events = new List<GameEvent>();

    public void AddEvent(GameEvent gameEvent)
    {
        events.Add(gameEvent);
    }

    public EntityAction(EntityMotor entity, List<GameEvent> events)
    {
        this.entity = entity;
        this.events = events;
    }
}

[System.Serializable]
public class GameEvent
{
    public ActionType actionType;
    public int value;

    public EntityMotor target;

    public GameEvent(ActionType actionType, int value, EntityMotor target)
    {
        this.actionType = actionType;
        this.value = value;
        this.target = target;
    }
}

public enum ActionType
{
    Attack,
    Shield,
    Heal,
}