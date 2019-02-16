using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command {

    private readonly string LEVEL_PARAM = "level";
    public GameObject levelPrefab;
    public GameObject up_in, right_in, down_in, left_in;
    
    public new void Start() {
        base.Start();
        paramPrefabs.Add(LEVEL_PARAM, levelPrefab);
    }

    public override int Execute(Robot robo) {
        return Next();
    }
    
    public new void FixedUpdate() {
        base.FixedUpdate();
        if (paramList.ContainsKey(LEVEL_PARAM) && paramList[LEVEL_PARAM] != null) {
            paramValue[LEVEL_PARAM] = paramList[LEVEL_PARAM].GetComponent<ParamDirection>().value;
            MarkLevel();
        }
    }

    public int GetLevel(Vector2 dir) {
        int level_addr = (int) (addr + dir.x + dir.y * 16);
        NumberConst numberConst = Processor.GetInstance().programmer.memory[level_addr].GetComponent<NumberConst>();
        if (numberConst != null)
            return numberConst.value;
        
        return -1;
    }
    
    private void MarkLevel() {
        up_in.gameObject.SetActive(false);
        right_in.gameObject.SetActive(false);
        down_in.gameObject.SetActive(false);
        left_in.gameObject.SetActive(false);
        if(paramValue[LEVEL_PARAM].Equals(new Vector2(0, -1))) up_in.gameObject.SetActive(true);
        if(paramValue[LEVEL_PARAM].Equals(new Vector2(1,  0))) right_in.gameObject.SetActive(true);
        if(paramValue[LEVEL_PARAM].Equals(new Vector2(0,  1))) down_in.gameObject.SetActive(true);
        if(paramValue[LEVEL_PARAM].Equals(new Vector2(-1, 0))) left_in.gameObject.SetActive(true);
    }
}
