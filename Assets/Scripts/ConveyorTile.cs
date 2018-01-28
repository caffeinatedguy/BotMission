using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorTile : FloorTile {

	[SerializeField]
	private Vector3 _direction = Vector3.zero;

	public override void MoveIntoTile(TileMover mover)
	{
		this.Blocked = true;
		if(_direction != Vector3.zero){
			SDD.Events.EventManager.Instance.Raise(new TileMoverEvent(mover.PlayerId, TileMoverEventTypes.Push, _direction));
		}
	}
		
}
