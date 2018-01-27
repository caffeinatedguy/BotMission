using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {


	private static TileManager _instance;

	public static TileManager Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<TileManager>();
			}

			return _instance;
		}
	}


	public int width = 10;
	public int height = 15;


	public GameObject[] tileTypes;

	private FloorTile[][] _floor;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {

		_floor = new FloorTile[width][];

		for(int x = 0; x < width; x++)
		{
			_floor[x] = new FloorTile[height];
			for(int y = 0; y < height; y++)
			{
				_floor[x][y] = new FloorTile(x,y);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
