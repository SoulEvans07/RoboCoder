using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Processor : MonoBehaviour {
	private static Processor instance;
	
	public GameObject programmerPanel;
	public ProgrammerPanel programmer;

	public GameObject robo;
	
	private static readonly Vector2 memory_size = new Vector2(16, 24);
	public int pointer = -1;
	public List<int> stack = new List<int>();

	private void Awake() {
		if (instance != null) {
			Destroy(instance);
		}
		instance = this;
	}

	public static Processor GetInstance() {
		return instance;
	}

	public void Start() {
		programmer = programmerPanel.GetComponent<ProgrammerPanel>();
	}

	private void FixedUpdate() {
		pointer = programmer.GetStart(0);
	}

	public void Step() {
		if (pointer != -1) {
			pointer = programmer.memory[pointer].GetComponent<Command>().Execute(robo.GetComponent<Robot>());
		} else {
			Debug.Log("Processor stopped.");
		}
	}
}
