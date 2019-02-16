using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamsPanel : MonoBehaviour {
	
	public List<GameObject> paramList = new List<GameObject>();
	
	private int padding = 10;
	private int border = 20;
	private int cellSize = 20;

	public GameObject actual; 

	public bool Open(ProgrammerPanel cpu, GameObject cell) {
		if (this.gameObject.activeSelf) {
			if (!actual.Equals(cell)) {
				this.actual = cell;
				return true;
			} else {
				this.gameObject.SetActive(false);
				return false;
			}
		}
		this.gameObject.SetActive(true);
		return true;
	}
	
	public void Init() {
		foreach (Transform child in this.transform) {
			Destroy(child.gameObject);
		}
		
		Vector2 size = this.GetComponent<RectTransform>().sizeDelta;
		int i = 0;
		int x = 0;
		int y = 0;
		while (i < paramList.Count) {
			x = 0;
			y = i;
			
			paramList[i].transform.SetParent(this.transform);
			float xPos = border + x * (cellSize + padding);
			float yPos = border + y * (cellSize + padding);
			Vector2 offmin = new Vector2(xPos, size.y - cellSize - yPos);
			Vector2 offmax = new Vector2(-size.x + cellSize + xPos, -yPos);
			paramList[i].GetComponent<RectTransform>().offsetMin = offmin;
			paramList[i].GetComponent<RectTransform>().offsetMax = offmax;
			paramList[i].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
			i++;
		}
	}
}
