using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberConst : Cell {
	public int value;
	public TextMeshProUGUI numberText;

	private void Start() {
		numberText.text = value.ToString();
	}
}
