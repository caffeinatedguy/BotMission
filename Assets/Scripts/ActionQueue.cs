using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionQueue : Events.EventHandler {


	private List<GameObject> _queue = new List<GameObject>();
	private bool _takingAction = false; 

	public TileMover _player;

	public Transform contentPanel;

	[SerializeField]
	private GameObject _moveForwardAction;
	[SerializeField]
	private GameObject _moveBackwardAction;
	[SerializeField]
	private GameObject _rotateLeftAction;
	[SerializeField]
	private GameObject _rotateRightAction;
	[SerializeField]
	private GameObject _pushAction;

	private int _maxQueueSize = 6;

	[SerializeField]
	private PlayerId _playerId;

	void Start () {

	}

	void Update () {

		if(_queue.Count > 0 && !_takingAction)
		{
			_takingAction = true;
			StartCoroutine(TakeActionAfterTime(_queue[0]));
			_queue.RemoveAt(0);
		}
	}

	public void AddToQueue(GameObject action)
	{

		action.transform.SetParent(contentPanel);

		_queue.Add(action);
	}

	public void AddToQueueFront(GameObject action)
	{
		_queue.Insert(0,action);
	}

	IEnumerator TakeActionAfterTime(GameObject o)
	{

		Action action = o.GetComponent<Action>();
		yield return new WaitForSeconds(action.Windup);


		action.Activate(_player);
		Destroy(o);
		_takingAction = false;
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
		if ((_playerId != e._playerId) || _queue.Count >= _maxQueueSize)
			return;

		Debug.Log(string.Format("HeaderText.OnClick({0})", e));

		switch (e._eventType)
		{
			case TileMoverEventTypes.Forward:
				AddToQueue((GameObject)GameObject.Instantiate(_moveForwardAction));
				break;
			case TileMoverEventTypes.Backward:
				AddToQueue((GameObject)GameObject.Instantiate(_moveBackwardAction));
				break;
			case TileMoverEventTypes.TurnLeft:
				AddToQueue((GameObject)GameObject.Instantiate(_rotateLeftAction));
				break;
			case TileMoverEventTypes.TurnRight:
				AddToQueue((GameObject)GameObject.Instantiate(_rotateRightAction));
				break;
			case TileMoverEventTypes.Push:
				GameObject tempPush = (GameObject)GameObject.Instantiate(_pushAction);
				tempPush.GetComponent<PushAction>().Direction = e._direction;
				AddToQueueFront(tempPush);
				break;
		}

	}

/* private List<GameObject> _queue = new List<GameObject>();
	private bool _takingAction = false;

	public TileMover _player;

	public Transform contentPanel;

	[SerializeField]
	private GameObject _moveForwardAction;
	[SerializeField]
	private GameObject _moveBackwardAction;
	[SerializeField]
	private GameObject _rotateLeftAction;
	[SerializeField]
	private GameObject _rotateRightAction;
	[SerializeField]
	private GameObject _pushAction;

	private int _maxQueueSize = 6;

	[SerializeField]
	private PlayerId _playerId;

	void Start () {

	}

	void Update () {

		if(_queue.Count > 0 && !_takingAction)
		{
			_takingAction = true;
			StartCoroutine(TakeActionAfterTime(_queue[0]));
		}
	}

	public void AddToQueue(GameObject action)
	{

		action.transform.SetParent(contentPanel);

		_queue.Add(action);
	}

	public void AddToQueueFront(GameObject action)
	{
		_queue.Insert(0,action);
	}

	IEnumerator TakeActionAfterTime(GameObject o)
	{

		Action action = o.GetComponent<Action>();
		yield return new WaitForSeconds(action.Windup);

		for(int i = 0; i < _queue.Count; i++)
		{
			Action temp =  _queue[i].GetComponent<Action>();
			temp.Activate(_player);
			_queue.RemoveAt(0);
			Destroy(temp.gameObject);
		}
		_takingAction = false;
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
		if ((_playerId != e._playerId) || _queue.Count >= _maxQueueSize)
			return;

		Debug.Log(string.Format("HeaderText.OnClick({0})", e));

		switch (e._eventType)
		{
			case TileMoverEventTypes.Forward:
				AddToQueue((GameObject)GameObject.Instantiate(_moveForwardAction));
				break;
			case TileMoverEventTypes.Backward:
				AddToQueue((GameObject)GameObject.Instantiate(_moveBackwardAction));
				break;
			case TileMoverEventTypes.TurnLeft:
				AddToQueue((GameObject)GameObject.Instantiate(_rotateLeftAction));
				break;
			case TileMoverEventTypes.TurnRight:
				AddToQueue((GameObject)GameObject.Instantiate(_rotateRightAction));
				break;
			case TileMoverEventTypes.Push:
				GameObject tempPush = (GameObject)GameObject.Instantiate(_pushAction);
				tempPush.GetComponent<PushAction>().Direction = e._direction;
				AddToQueueFront(tempPush);
				break;
		}

	}*/

		
}
