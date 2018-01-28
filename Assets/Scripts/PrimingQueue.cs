using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimingQueue : Events.EventHandler {


    private List<TileMoverEvent> _queueTileMoverEvents = new List<TileMoverEvent>();
    private List<GameObject> _queue = new List<GameObject>();
	private bool _takingAction = false; 

	public TileMover _player;

	public Transform contentPanel;

    [SerializeField]
    private float _waitToActionQueue = 2.0f;
    [SerializeField]
    private ActionQueue _actionQueue;
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
			StartCoroutine(AddToPrimingAfterTime(_waitToActionQueue));
		}
	}

	public void AddToQueue(GameObject action, TileMoverEvent e)
	{

		action.transform.SetParent(contentPanel);

		_queue.Add(action);
        _queueTileMoverEvents.Add(e);
    }

	public void AddToQueueFront(GameObject action, TileMoverEvent e)
	{
		_queue.Insert(0,action);
        _queueTileMoverEvents.Insert(0, e);
    }

	IEnumerator AddToPrimingAfterTime(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);

        //Add each to the queue
        while(_queue.Count != 0)
        {
            //Add to Action Queue
            _actionQueue.AddTileMoverEvent(_queueTileMoverEvents[0]);
            //Destroy Icon
            Destroy(_queue[0]);

            //Remove them
            _queueTileMoverEvents.RemoveAt(0);
            _queue.RemoveAt(0);   
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
				AddToQueue((GameObject)GameObject.Instantiate(_moveForwardAction), e);
				break;
			case TileMoverEventTypes.Backward:
				AddToQueue((GameObject)GameObject.Instantiate(_moveBackwardAction), e);
				break;
			case TileMoverEventTypes.TurnLeft:
				AddToQueue((GameObject)GameObject.Instantiate(_rotateLeftAction), e);
				break;
			case TileMoverEventTypes.TurnRight:
				AddToQueue((GameObject)GameObject.Instantiate(_rotateRightAction), e);
				break;
			case TileMoverEventTypes.Push:
				GameObject tempPush = (GameObject)GameObject.Instantiate(_pushAction);
				tempPush.GetComponent<PushAction>().Direction = e._direction;
				AddToQueueFront(tempPush, e);
				break;
		}

	}
		
}
