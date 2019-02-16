using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRightCommand : Command {

	public override int Execute(Robot robo) {
		robo.TurnRight();
		return Next();
	}
}
