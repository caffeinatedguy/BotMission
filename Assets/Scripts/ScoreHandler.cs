using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : Events.EventHandler {

	public Text _text;
	public PlayerId _playerId;

	public GameObject _winnerPanel;
	public Text _winnerText;

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
		//Check if this player is the right player otherwise return
		if (_playerId != s._playerId)
			return;

		_text.text = (int.Parse(_text.text) + s._amount).ToString();

		if(int.Parse(_text.text) >= 10)
		{
			_winnerPanel.SetActive(true);
			if(_playerId.ToString() == "GP1" || _playerId.ToString() == "Wasd")
			{
				_winnerText.text = "Player 1 Wins!";
			} else if(_playerId.ToString() == "GP2")
			{
				_winnerText.text = "Player 2 Wins!";
			}
		}

	}


}
