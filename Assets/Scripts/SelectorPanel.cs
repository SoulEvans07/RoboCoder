using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorPanel : MonoBehaviour {

	public List<GameObject> commands = new List<GameObject>();
	public List<GameObject> buttons = new List<GameObject>();
	public GameObject buttonBase;

	public int padding = 2;
	public int border = 5;
	public int cellSize = 16;

	public ProgrammerPanel cpu;

	public void Open(ProgrammerPanel cpu, GameObject cell) {
		this.gameObject.SetActive(true);
		this.cpu = cpu;
		Init(cell.GetComponent<Cell>().addr);
	}
	
	public void Init(int place) {
		buttons.Clear();
		Vector2 size = this.GetComponent<RectTransform>().sizeDelta;
		int i = 0;
		int x = 0;
		int y = 0;
		while (i < commands.Count) {
			x = i % 5;
			y = (i - x) / 5;
			GameObject button = Instantiate(buttonBase, this.transform);
			GameObject command = commands[i];
			
			button.name = "Tile [" + command.name + "]";
			float xPos = border + x * (cellSize + padding);
			float yPos = border + y * (cellSize + padding);
			Vector2 offmin = new Vector2(xPos, size.y - cellSize - yPos);
			Vector2 offmax = new Vector2(-size.x + cellSize + xPos, -yPos);
			button.GetComponent<RectTransform>().offsetMin = offmin;
			button.GetComponent<RectTransform>().offsetMax = offmax;
			button.GetComponent<Image>().sprite = command.GetComponent<Image>().sprite;
			button.transform.SetParent(this.transform);
			button.GetComponent<Button>().onClick
				.AddListener(delegate {
					cpu.PlaceCell(command, place); 
					this.gameObject.SetActive(false);
				});
			buttons.Add(button);
			i++;
		}
	}

	public void AddCommand(GameObject command) {
		commands.Add(command);
	}
}
