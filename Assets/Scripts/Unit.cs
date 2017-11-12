using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	//private new BoxCollider collider;
	[HideInInspector]
	public Projector Projector { get; set; }
	[HideInInspector]
	public bool Selected { get { return Projector.enabled; } }

	public float Speed = 0.1f;

	private Vector3 targetPos;

	// Use this for initialization
	void Start()
	{
		//collider = GetComponent<BoxCollider>();
		Projector = GetComponentInChildren<Projector>();
		Projector.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		//if(Input.GetMouseButtonDown(0))
		//{
		//	RaycastHit hitInfo = new RaycastHit();
		//	bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
		//	if(hit)
		//	{
		//		if(hitInfo.collider == collider)
		//		{
		//			Debug.Log("Clicked on unit");
		//		}
		//	}
		//}

		
	}
}
