using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScore : MonoBehaviour
{

	public PlayerId _playerID;
	public int _amount;

    private void OnTriggerEnter(Collider other)
    {
		Debug.Log("Collider entered trigger " + other.gameObject.name);

		if(other.tag == "Ball"){
			SDD.Events.EventManager.Instance.Raise(new ScoreEvent(_playerID, _amount));
		}

		StartCoroutine(PoolObjectAfterTime(other.gameObject, 1.0f));
    }

	IEnumerator PoolObjectAfterTime(GameObject obj, float time)
	{
		yield return new WaitForSeconds(time);
		ObjectPool.instance.PoolObject(obj);
	}
}
