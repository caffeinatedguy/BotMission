using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardAction : Action {



	public override void Activate(TileMover player)
	{
		player.MoveForward();
	}

}
