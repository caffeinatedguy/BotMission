using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour {


	private int _posY = 0;
	private int _posX = 0;


	void Start()
	{
		InitNeighbors();
	}

	void Update()
	{

	}

	public FloorTile(int posX, int posY)
	{
		_posX = posX;
		_posY = posY;
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

	private void InitNeighbors()
	{
		RaycastHit info;

		if(Physics.Raycast(transform.position + new Vector3(0f,0.2f,0f), new Vector3(1f,0f,0f), out info, 2.0f)){
			_eastTile = info.collider.gameObject.GetComponent<FloorTile>();
		}
		if(Physics.Raycast(transform.position + new Vector3(0f,0.2f,0f), new Vector3(-1f,0f,0f), out info, 2.0f)){
			_westTile = info.collider.gameObject.GetComponent<FloorTile>();
		}
		if(Physics.Raycast(transform.position + new Vector3(0f,0.2f,0f), new Vector3(0f,0f,1f), out info, 2.0f)){
			_northTile = info.collider.gameObject.GetComponent<FloorTile>();
		}
		if(Physics.Raycast(transform.position + new Vector3(0f,0.2f,0f), new Vector3(0f,0f,-1f), out info, 2.0f)){
			_southTile = info.collider.gameObject.GetComponent<FloorTile>();
		}
	}
}
