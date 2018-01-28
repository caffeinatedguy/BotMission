using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileMover : Events.EventHandler
{
    [SerializeField]
    private PlayerId _playerId;

    [SerializeField]
	private FloorTile _currentTile;

	[SerializeField]
	private GameObject _heading;

	private GameObject _target;

	private Quaternion _targetRotation;


	// Use this for initialization
	void Start ()
    {
		_target = transform.gameObject;
		_targetRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	/*	if(Input.GetKeyDown(KeyCode.W))
		{
			MoveForward();
		}

		if(Input.GetKeyDown(KeyCode.S))
		{
			MoveBackward();
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			Rotate(-90f);
		}

		if(Input.GetKeyDown(KeyCode.D))
		{
			Rotate(90f);
		}*/

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

    public override void SubscribeEvents()
    {
        Debug.Log(string.Format("HeaderText.SubscribeEvents() name {0}", name));

        SDD.Events.EventManager.Instance.AddListener<TileMoverEvent>(OnTileMoverEvent);
    }

    public override void UnsubscribeEvents()
    {
        Debug.Log(string.Format("HeaderText.UnsubscribeEvents() name {0}", name));

        SDD.Events.EventManager.Instance.RemoveListener<TileMoverEvent>(OnTileMoverEvent);
    }

    public void OnTileMoverEvent(TileMoverEvent e)
    {
        //Check if this player is the right player otherwise return
        if (_playerId != e._playerId)
            return;

        Debug.Log(string.Format("HeaderText.OnClick({0})", e));

        switch (e._eventType)
        {
            case TileMoverEventTypes.Forward:
                MoveForward();
                break;
            case TileMoverEventTypes.Backward:
                MoveBackward();
                break;
            case TileMoverEventTypes.TurnLeft:
                Rotate(-90);
                break;
            case TileMoverEventTypes.TurnRight:
                Rotate(90);
                break;
        }

    }
}
