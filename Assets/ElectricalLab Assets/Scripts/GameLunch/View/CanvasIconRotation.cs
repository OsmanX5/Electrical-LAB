using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasIconRotation : MonoBehaviour
{

	public float rotationSpeed = 45f;   // The rotation speed in degrees per second

	private RectTransform rectTransform;    // The RectTransform component of the icon

	void Start()
	{
		// Get the RectTransform component of the icon
		rectTransform = GetComponent<RectTransform>();
	}

	void Update()
	{
		// Rotate the icon around the Z axis
		rectTransform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
	}

}