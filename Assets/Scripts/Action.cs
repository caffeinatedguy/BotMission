using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour {

    [SerializeField]
	private float _windup = 0.5f;

	public float Windup
	{
		get{
			return _windup;
		}
		set{
			_windup = value;
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
