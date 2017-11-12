using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
	public float width = 1f;
	public float height = 1f;

	private MeshFilter filter;
	private new MeshRenderer renderer;

	// Use this for initialization
	void Start ()
	{
		filter = GetComponent<MeshFilter>();
		renderer = GetComponent<MeshRenderer>();

		var mesh = new Mesh();
		var verts = new List<Vector3>();
		verts.Add(new Vector3(0f, 0f, 0f));
		verts.Add(new Vector3(0f, 0f, height / 2.0f));
		verts.Add(new Vector3(width / 2.0f, 0f, height / 4.0f));
		verts.Add(new Vector3(width / 2.0f, 0f, -height / 4.0f));
		verts.Add(new Vector3(0f, 0f, -height / 2.0f));
		verts.Add(new Vector3(-width / 2.0f, 0f, -height / 4.0f));
		verts.Add(new Vector3(-width / 2.0f, 0f, height / 4.0f));
		mesh.SetVertices(verts);

		var indices = new int[] { 0, 2, 1,
								  0, 3, 2,
								  0, 4, 3,
								  0, 5, 4,
								  0, 6, 5,
								  0, 1, 6};
		mesh.SetIndices(indices, MeshTopology.Triangles, 0);

		filter.mesh = mesh;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}