using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardCommand : Command {
    
    public override int Execute(Robot robo) {
        robo.Forward();
        return Next();
    }
}
