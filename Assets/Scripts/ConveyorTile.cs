using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorTile : FloorTile {

	[SerializeField]
	private Vector3 _direction = Vector3.zero;

	public override void MoveIntoTile(TileMover mover)
	{
		this.Blocked = true;
		if(_direction != Vector3.zero){
			SDD.Events.EventManager.Instance.Raise(new TileMoverEvent(mover.PlayerId, TileMoverEventTypes.Push, _direction));
		}
	}

	void OnCollisionEnter(Collision collision)	{

		if(collision.collider.tag == "Ball")
		{
			collision.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(_direction * 0.05f, collision.contacts[0].point);

		}

	}

	void OnCollisionStay(Collision collision)	{

		if(collision.collider.tag == "Ball")
		{
			collision.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(_direction * 10.0f, collision.contacts[0].point,ForceMode.Acceleration);

		}

	}
		
}
