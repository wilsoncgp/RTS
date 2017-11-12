using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
	bool isSelecting = false;
	Vector3 originalMousePos;
	Unit[] units;
	int unitsNum;

	void Start()
	{
		units = new Unit[8];

		var unitGOs = GetComponentsInChildren<Unit>();
		unitsNum = Mathf.Min(units.Length, unitGOs.Length);
		for(int i = 0; i < unitsNum; i++)
		{
			units[i] = unitGOs[i];
		}
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			isSelecting = true;
			originalMousePos = Input.mousePosition;
		}

		if(Input.GetMouseButtonUp(0))
		{
			isSelecting = false;
		}

		UpdateSelection();

		
	}

	void OnGUI()
	{
		if(isSelecting)
		{
			var rect = Utils.GetScreenRect(originalMousePos, Input.mousePosition);
			Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
			Utils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
		}
	}

	public void UpdateSelection()
	{
		if (!isSelecting) return;

		for (int i = 0; i < unitsNum; i++)
		{
			units[i].Projector.enabled = IsWithinSelectionBounds(units[i].gameObject);
		}
	}

	public bool IsWithinSelectionBounds(GameObject gameObject)
	{
		if (!isSelecting) return false;

		var camera = Camera.main;
		var viewportBounds = Utils.GetViewportBounds(camera, originalMousePos, Input.mousePosition);

		return viewportBounds.Contains(camera.WorldToViewportPoint(gameObject.transform.position));
	}
}
