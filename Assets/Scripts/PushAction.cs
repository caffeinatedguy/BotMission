using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAction : Action {

	private Vector3 _direction;
	public Vector3 Direction{
		get{
			return _direction;
		}
		set{
			_direction = value;
		}
	}


	public override void Activate(TileMover player)
	{
		player.Push(_direction);
	}

}
