using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
	public string cellName = "Cell";
	public int addr;
	
	public Dictionary<string, GameObject> paramPrefabs = new Dictionary<string, GameObject>();
	public Dictionary<string, GameObject> paramList = new Dictionary<string, GameObject>();
	public Dictionary<string, object> paramValue = new Dictionary<string, object>();
}
