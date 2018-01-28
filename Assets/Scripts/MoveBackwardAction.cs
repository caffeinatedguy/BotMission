using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwardAction : Action {

	public override void Activate(TileMover player)
	{
		player.MoveBackward();
	}
}
