using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour {


	public GameObject _pausePanel;

	private bool _paused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(_paused)
			{
				_paused = false;
				_pausePanel.SetActive(false);
				Time.timeScale = 1.0f;
			} else{
				_paused = true;
				_pausePanel.SetActive(true);
				Time.timeScale = 0.0f;
			}
		}
	}
}
