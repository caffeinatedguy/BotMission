using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour {


	void Start()
	{
	}

	void Update()
	{

	}



	public virtual void MoveIntoTile(TileMover mover)
	{
		
	}

	public FloorTile GetTile(Vector3 direction)
	{
		
		RaycastHit info;

		if(Physics.Raycast(transform.position + new Vector3(0f,0.2f,0f), direction, out info, 2.0f)){
			return info.collider.gameObject.GetComponent<FloorTile>();
		}else{
			return null;
		}

	}

}
