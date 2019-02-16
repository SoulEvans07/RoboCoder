using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgrammerPanel : MonoBehaviour {

	public GameObject empty;
	public GameObject selector;
	public GameObject editor;
	
	private int border = 6;
	private int padding = 2;
	private int cellSize = 16;

	public List<GameObject> memory;

	void Start () {
		ClearMemory();
	}

	public void ClearMemory() {
		memory = new List<GameObject>();
		Vector2 size = this.GetComponent<RectTransform>().sizeDelta;
		for (int y = 0; y < 24; y++) {
			for (int x = 0; x < 16; x++) {
				GameObject cell = Instantiate(empty, this.transform);
				cell.name = "Cell [" + x + "; " + y + "]";
				PositionCell(cell, x, y);
				cell.GetComponent<Button>().onClick.AddListener(delegate { selector.GetComponent<SelectorPanel>().Open(this, cell); });
				cell.GetComponent<Cell>().addr = y * 16 + x;
				memory.Add(cell);
			}
		}
	}

	public void PlaceCell(GameObject tile, int addr) {
		GameObject cell = Instantiate(tile, this.transform);
		Vector2 pos = Address2Pos(addr);
		cell.name = cell.GetComponent<Cell>().cellName + " [" + pos.x + ", " + pos.y + "]";
		
		cell.GetComponent<CellButton>().onClick
			.AddListener(delegate { selector.GetComponent<SelectorPanel>().Open(this, cell); });
		cell.GetComponent<CellButton>().onRightClick
			.AddListener(delegate {
				if (editor.GetComponent<ParamsPanel>().Open(this, cell)) {
					Dictionary<String, GameObject> prefabs = cell.GetComponent<Cell>().paramPrefabs;
					editor.GetComponent<ParamsPanel>().paramList.Clear();
					foreach (string key in prefabs.Keys) {
						if(cell.GetComponent<Cell>().paramList.ContainsKey(key))
							Destroy(cell.GetComponent<Cell>().paramList[key]);
						GameObject param = cell.GetComponent<Cell>().paramList[key] = Instantiate(prefabs[key]);
						param.name = "Param ["+key+"]";
						if(cell.GetComponent<Cell>().paramValue.ContainsKey(key))
							param.GetComponent<Parameter>().setValue(cell.GetComponent<Cell>().paramValue[key]);
						editor.GetComponent<ParamsPanel>().paramList.Add(param);
					}
					editor.GetComponent<ParamsPanel>().Init();
				}
			});
		cell.GetComponent<Cell>().addr = addr;
		PositionCell(cell, (int)pos.x, (int)pos.y);
		Destroy(memory[addr]);
		memory[addr] = cell;
	}

	private Vector2 Address2Pos(int addr) {
		return new Vector2(
			addr % 16,
			addr / 16
		);
	}

	private void PositionCell(GameObject cell, int x, int y) {
		Vector2 size = this.GetComponent<RectTransform>().sizeDelta;
		float xPos = border + x * (cellSize + padding);
		float yPos = border + y * (cellSize + padding);
		cell.transform.SetParent(this.transform);
		editor.transform.SetAsLastSibling();
		selector.transform.SetAsLastSibling();
		cell.GetComponent<RectTransform>().offsetMin = new Vector2(xPos, size.y - cellSize - yPos);
		cell.GetComponent<RectTransform>().offsetMax = new Vector2(-size.x + cellSize + xPos, -yPos);
	}

	public int GetStart(int level) {
		foreach (GameObject cell in memory) {
			StartCommand start = cell.GetComponent<StartCommand>();
			if (start != null && start.paramValue.ContainsKey("level")
			    && start.GetLevel((Vector2) start.paramValue["level"]).Equals(level)) {
				return start.addr;
			}
		}
		return -1;
	}
}
