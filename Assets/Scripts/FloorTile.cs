using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile {


	private int _posY = 0;
	private int _posX = 0;

	public FloorTile(int posX, int posY)
	{
		_posX = posX;
		_posY = posY;
		Debug.Log("Created Tile at " + posX + " " + posY);
	}

	public virtual void MoveIntoTile(TileMover mover)
	{
		
	}

}
