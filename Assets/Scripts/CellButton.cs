using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellButton : Button {
    public UnityEvent onRightClick;
    
    public override void OnPointerClick(PointerEventData eventData) {
        if (eventData.pointerId == -1) {
            this.onClick.Invoke();
        } else if (eventData.pointerId == -3)
            Debug.Log("Middle click");
        else if (eventData.pointerId == -2)
            this.onRightClick.Invoke();
    }

    public void AddRightClickListener(UnityAction call) {
        onRightClick.AddListener(call);
    }
    
    
}
