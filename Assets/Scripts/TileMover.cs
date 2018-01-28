using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileMover : MonoBehaviour/* : Events.EventHandler*/
{
    [SerializeField]
    private PlayerId _playerId;

    [SerializeField]
	private FloorTile _currentTile;

	[SerializeField]
	private GameObject _heading;

	private GameObject _target;

	private Quaternion _targetRotation;


	void Start ()
    {
		_target = transform.gameObject;
		_targetRotation = transform.rotation;
	}
	
	void Update () {

		transform.position = Vector3.Lerp(transform.position, new Vector3(_target.gameObject.transform.position.x, transform.position.y, _target.gameObject.transform.position.z), 7f * Time.deltaTime);
		transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, 10f * Time.deltaTime);
	
	}

	private void Move(Vector3 direction)
	{
		FloorTile tempTile = _currentTile.GetTile(direction);
		if(tempTile)
		{
			_currentTile = tempTile;
			_target = tempTile.gameObject;
		}
	}

	public void Push(Vector3 direction)
	{
		
	}

	public void MoveForward()
	{
		Move(Heading());
	}

	public void MoveBackward()
	{
		Move(Heading() * -1.0f);
	}

	public void Rotate(float degrees)
	{
		_targetRotation *=  Quaternion.AngleAxis(degrees, Vector3.up);
	}

	private Vector3 Heading()
	{

		return _heading.gameObject.transform.position - gameObject.transform.position;
	}
}
