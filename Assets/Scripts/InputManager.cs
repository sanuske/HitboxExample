using System.Collections;
using UnityEngine;


public class InputManager : MonoBehaviour
{
	public bool jumpPressed = false;
	public bool DashPressed = false;
	public float moveDirection = 0;


	// Update is called once per frame
	void Update()
	{
		jumpPressed = Input.GetKeyDown(KeyCode.Space);
		DashPressed = Input.GetKeyDown(KeyCode.LeftShift);
		moveDirection = Input.GetAxis("Horizontal");

	}
}
