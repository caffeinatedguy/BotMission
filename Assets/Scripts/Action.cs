using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {

	private float _windup = 1.0f;

	public float Windup
	{
		get{
			return _windup;
		}
	}

	private float _cooldown = 0.0f;

	public float Cooldown
	{
		get{
			return _cooldown;
		}
	}
		
	public virtual void Activate(TileMover player)
	{
		
	}
		
}
