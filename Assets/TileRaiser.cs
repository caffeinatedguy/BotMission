using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRaiser : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Tile")
		{
			other.gameObject.GetComponent<FloorTile>().RaiseTile();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Tile")
		{
			other.gameObject.GetComponent<FloorTile>().LowerTile();
		}
	}
}
