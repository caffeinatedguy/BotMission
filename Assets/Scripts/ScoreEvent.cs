using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEvent : SDD.Events.Event {

	public ScoreEvent(PlayerId id, int amount)
	{
		_playerId = id;
		_amount = amount;
	}

	public PlayerId _playerId;
	public int _amount;
}
