using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.UI;

public abstract class Command : Cell {
	public GameObject nextPrefab;
	private readonly string NEXT_PARAM = "next";
	public GameObject up_out, right_out, down_out, left_out;

	public void Start() {
		paramPrefabs.Add(NEXT_PARAM, nextPrefab);
	}

	public void FixedUpdate() {
		if (paramList.ContainsKey(NEXT_PARAM) && paramList[NEXT_PARAM] != null) {
			paramValue[NEXT_PARAM] = paramList[NEXT_PARAM].GetComponent<ParamDirection>().value;
			MarkNext();
		}
	}
	
	public abstract int Execute(Robot robo);

	public int Next() {
		return GetNext((Vector2)paramValue[NEXT_PARAM]);
	}

	public int GetNext(Vector2 dir) {
		return (int) (addr + dir.x + dir.y * 16);
	}
	
	public void MarkNext() {
		up_out.gameObject.SetActive(false);
		right_out.gameObject.SetActive(false);
		down_out.gameObject.SetActive(false);
		left_out.gameObject.SetActive(false);
		if(paramValue[NEXT_PARAM].Equals(new Vector2(0, -1))) up_out.gameObject.SetActive(true);
		if(paramValue[NEXT_PARAM].Equals(new Vector2(1,  0))) right_out.gameObject.SetActive(true);
		if(paramValue[NEXT_PARAM].Equals(new Vector2(0,  1))) down_out.gameObject.SetActive(true);
		if(paramValue[NEXT_PARAM].Equals(new Vector2(-1, 0))) left_out.gameObject.SetActive(true);
	}
}
