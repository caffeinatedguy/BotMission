using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayBetween : MonoBehaviour {


	public GameObject _target1;
	public GameObject _target2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = (_target1.transform.position + ((_target2.transform.position - _target1.transform.position) * 0.5f));
	}
}
