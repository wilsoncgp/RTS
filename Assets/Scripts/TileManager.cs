using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
	private Hexagon[] tiles;
	public Hexagon tilePrefab;

	public int gridSizeX = 3;
	public int gridSizeY = 3;

	// Use this for initialization
	void Start ()
	{
		tiles = new Hexagon[19];

		for (int i = 0; i < tiles.Length; i++)
		{
			tiles[i] = Instantiate(tilePrefab);
		}

		
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
