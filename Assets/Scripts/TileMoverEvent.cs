using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileMoverEventTypes
{
    None,
    Forward,
    Backward,
    TurnLeft,
    TurnRight,
	Push
}


public class TileMoverEvent : SDD.Events.Event
{
    public TileMoverEvent(PlayerId id, TileMoverEventTypes type)
    {
        _playerId = id;
        _eventType = type;
		_direction = Vector3.zero;
    }

	public TileMoverEvent(PlayerId id, TileMoverEventTypes type, Vector3 direction)
	{
		_playerId = id;
		_eventType = type;
		_direction = direction;
	}
    public PlayerId _playerId;
    public TileMoverEventTypes _eventType;
	public Vector3 _direction;
}
