using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : Events.EventHandler {

	public GameObject _spawn;

	public int _maxObjects;
	public int _totalObjects = 0;

	public Transform _spawnHeading;

	public float _spawnForce;
	public float _spawnTime;

	private bool _spawning = false;


	
	// Update is called once per frame
	void Update () {
		if(!_spawning && _totalObjects < _maxObjects)
		{
			_spawning = true;
			_totalObjects++;
			StartCoroutine(SpawnAfterTime(Random.Range(_spawnTime * 0.5f, _spawnTime * 1.5f)));
		}
	}

	IEnumerator SpawnAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		GameObject temp = (GameObject)GameObject.Instantiate(_spawn);
		temp.transform.position = transform.position;
		temp.GetComponent<Rigidbody>().AddForce((_spawnHeading.position - transform.position).normalized * Random.Range(_spawnForce * 0.75f, _spawnForce * 1.25f));
		_spawning = false;
	}

	public override void SubscribeEvents()
	{
		Debug.Log(string.Format("HeaderText.SubscribeEvents() name {0}", name));

		SDD.Events.EventManager.Instance.AddListener<ScoreEvent>(OnScoreEvent);
	}

	public override void UnsubscribeEvents()
	{
		Debug.Log(string.Format("HeaderText.UnsubscribeEvents() name {0}", name));

		SDD.Events.EventManager.Instance.RemoveListener<ScoreEvent>(OnScoreEvent);
	}

	public void OnScoreEvent(ScoreEvent s)
	{
		_totalObjects--;
	}
}
