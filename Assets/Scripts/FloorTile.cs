using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour {


	private bool _blocked = false;

	public bool Blocked
	{
		get{
			return _blocked;
		}
		set
		{
			_blocked = value;
		}
	}

	void Start()
	{
	}

	void Update()
	{

	}



	public virtual void MoveIntoTile(TileMover mover)
	{
		_blocked = true;
	}

	public FloorTile GetTile(Vector3 direction)
	{
		Debug.Log("Casting in direction " + direction);
		RaycastHit info;

		if(Physics.Raycast(transform.position + new Vector3(0f,0.2f,0f), direction, out info, 2.0f)){

			FloorTile tile = info.collider.gameObject.GetComponent<FloorTile>();
			if(!tile.Blocked){
				//tile.Blocked = true;
				_blocked = false;
				return info.collider.gameObject.GetComponent<FloorTile>();
			}
		}

		return null;
	}
}
