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

	public GameObject queueImage;

	private int _maxQueueSize = 6;

	[SerializeField]
	private PlayerId _playerId;

	void Start () {
		
	}
	
	// Update is called once per frame
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
		}

	}
		
}
