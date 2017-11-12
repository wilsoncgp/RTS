﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
	static Texture2D _whiteTexture;
	public static Texture2D WhiteTexture
	{
		get
		{
			if(_whiteTexture == null)
			{
				_whiteTexture = new Texture2D(1, 1);
				_whiteTexture.SetPixel(0, 0, Color.white);
				_whiteTexture.Apply();
			}

			return _whiteTexture;
		}
	}

	public static void DrawScreenRect(Rect rect, Color color)
	{
		GUI.color = color;
		GUI.DrawTexture(rect, WhiteTexture);
		GUI.color = Color.white;
	}

	public static void DrawScreenRectBorder(Rect rect, float thickness, Color color)
	{
		Utils.DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
		Utils.DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
		Utils.DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
		Utils.DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
	}

	public static Rect GetScreenRect(Vector3 screenPos1, Vector3 screenPos2)
	{
		// Move origin from bottom left to top left
		screenPos1.y = Screen.height - screenPos1.y;
		screenPos2.y = Screen.height - screenPos2.y;

		// Calculate corners
		var topLeft = Vector3.Min(screenPos1, screenPos2);
		var bottomRight = Vector3.Max(screenPos1, screenPos2);

		// Create Rect
		return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
	}

	public static Bounds GetViewportBounds(Camera camera, Vector3 screenPos1, Vector3 screenPos2)
	{
		var v1 = Camera.main.ScreenToViewportPoint(screenPos1);
		var v2 = Camera.main.ScreenToViewportPoint(screenPos2);
		var min = Vector3.Min(v1, v2);
		var max = Vector3.Max(v1, v2);
		min.z = camera.nearClipPlane;
		max.z = camera.farClipPlane;

		var bounds = new Bounds();
		bounds.SetMinMax(min, max);
		return bounds;
	}
}
