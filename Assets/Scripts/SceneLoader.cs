using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadSoccer()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("game");
	}

	public void LoadMaze()
	{
		Time.timeScale = 1f;

		SceneManager.LoadScene("Maze");

	}

    public void TurnOnGO(GameObject obj, GameObject obj2)
    {
        obj.active = true;
        obj2.active = false;
    }

    public void TurnOffGO(GameObject obj, GameObject obj2)
    {
        obj.active = false;
        obj2.active = true;
    }

    public void LoadMenu()
	{
		Time.timeScale = 1f;

		SceneManager.LoadScene("MainMenu");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
