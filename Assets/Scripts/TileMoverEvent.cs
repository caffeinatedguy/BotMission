using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileMoverEventTypes
{
    None,
    Forward,
    Backward,
    TurnLeft,
    TurnRight
}


public class TileMoverEvent : SDD.Events.Event
{
    public TileMoverEvent(PlayerId id, TileMoverEventTypes type)
    {
        _playerId = id;
        _eventType = type;
    }
    public PlayerId _playerId;
    public TileMoverEventTypes _eventType;
}
