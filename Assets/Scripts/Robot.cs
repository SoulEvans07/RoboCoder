using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
	public Vector2 localPos = new Vector2(0, 0);
	public Vector2 dir = new Vector2(0, -1);

	public void Forward() {
		localPos += dir;
	}

	public void TurnRight() {
		dir = new Vector2(-dir.y, dir.x);
	}

	public void TurnLeft() {
		dir = new Vector2(dir.y, -dir.x);
	}
}
