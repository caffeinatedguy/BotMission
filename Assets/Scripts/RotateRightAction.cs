using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRightAction : Action {

	public override void Activate(TileMover player)
	{
		player.Rotate(90f);
	}
}
