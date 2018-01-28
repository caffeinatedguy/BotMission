using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : Events.EventHandler {

	public Text _text;
	public PlayerId _playerId;

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
		Debug.Log("Received Score Event");
		//Check if this player is the right player otherwise return
		if (_playerId != s._playerId)
			return;

		Debug.Log("Text is " + _text.text + " As a number " + int.Parse(_text.text));
		_text.text = (int.Parse(_text.text) + s._amount).ToString();
	}
}
