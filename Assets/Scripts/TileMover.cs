using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class QueueItem
{
	public QueueItem(float rot, Vector3 dir)
	{
		rotation = rot;
		direction = dir;
	}
	public float rotation = 0.0f;
	public Vector3 direction = Vector3.zero;
}


public class TileMover : MonoBehaviour
{
	[SerializeField]
	private PlayerId _playerId;

	public PlayerId PlayerId
	{
		get{
			return _playerId;
		}
	}

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
		_currentTile.MoveIntoTile(this);
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
			tempTile.MoveIntoTile(this);
			_currentTile = tempTile;
			_target = tempTile.gameObject;
		}
	}

	public void Push(Vector3 direction)
	{
		Move(direction);
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

	/*[SerializeField]
	private PlayerId _playerId;

	public PlayerId PlayerId
	{
		get{
			return _playerId;
		}
	}

	[SerializeField]
	private FloorTile _currentTile;

	[SerializeField]
	private GameObject _heading;

	private GameObject _target;

	private Quaternion _targetRotation;

	private bool _moving = false;
	private bool _turning = false;

	private List<QueueItem> _queue = new List<QueueItem>();

	void Start ()
	{
		_target = transform.gameObject;
		_targetRotation = transform.rotation;
		_currentTile.MoveIntoTile(this);
	}

	void Update () {

		if(((_target.transform.position - transform.position).magnitude < 1.0f) && _queue.Count > 0)
		{
			//Move(_queue[0]);
			_queue.RemoveAt(0);
		}

		transform.position = Vector3.Lerp(transform.position, new Vector3(_target.gameObject.transform.position.x, transform.position.y, _target.gameObject.transform.position.z), 7f * Time.deltaTime);
		transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, 10f * Time.deltaTime);

	}

	private void Move(Vector3 direction)
	{
		FloorTile tempTile = _currentTile.GetTile(direction);
		if(tempTile)
		{
			tempTile.MoveIntoTile(this);
			_currentTile = tempTile;
			_target = tempTile.gameObject;
		}
	}

	private void AddtoQueue(float rotation, Vector3 direction)
	{
		_queue.Add(new QueueItem(rotation, direction));
	}

	public void Push(Vector3 direction)
	{
		Move(direction);
	}

	public void MoveForward()
	{
		AddtoQueue(0.0f, Heading());
		//Move(Heading());
	}

	public void MoveBackward()
	{
		AddtoQueue(0.0f, (Heading() * -1.0f));
		//Move(Heading() * -1.0f);
	}

	public void Rotate(float degrees)
	{
		AddtoQueue(degrees, Vector3.zero);
		//_targetRotation *=  Quaternion.AngleAxis(degrees, Vector3.up);
	}

	private Vector3 Heading()
	{
		return _heading.gameObject.transform.position - gameObject.transform.position;
	}*/

}
