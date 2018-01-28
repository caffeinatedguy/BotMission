using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionQueue : MonoBehaviour {

	private List<Action> _queue = new List<Action>();
	private bool _takingAction = false; 

	public TileMover _player;

	public Transform contentPanel;

	public Action moveForwardAction;

	public GameObject queueImage;

	private int _maxQueueSize = 6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.W))
		{
			Debug.Log("Adding move forward to queue");
			AddToQueue(moveForwardAction);
		}

		if(_queue.Count > 0 && !_takingAction)
		{
			Debug.Log("Starting coro");
			_takingAction = true;
			StartCoroutine(TakeActionAfterTime(_queue[0],_queue[0].Windup));
			_queue.RemoveAt(0);
		}
	}

	public void AddToQueue(Action action)
	{
		if(_queue.Count > _maxQueueSize)
		{
			return;
		}
		GameObject newIcon = (GameObject)GameObject.Instantiate(queueImage);
		Image image = newIcon.GetComponent<Image>();
		image.sprite = action.Image;
		newIcon.transform.SetParent(contentPanel);
		action.uiImage = newIcon;
		_queue.Add(action);
	}

	IEnumerator TakeActionAfterTime(Action action, float time)
	{
		Debug.Log("Added Action to Queue");

		yield return new WaitForSeconds(time);
		Debug.Log("Taking Action");
		action.Activate(_player);
		Destroy(action.uiImage);
		_takingAction = false;
	}
		
}
