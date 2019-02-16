using UnityEngine;
using UnityEngine.UI;

public class ParamDirection : Parameter {
    public bool input;
    public Vector2 value;
    public Color color;

    public GameObject up, right, down, left;

    public void setX(int x) {
        value.x = x;
    }

    public void setY(int y) {
        value.y = y;
        Mark();
    }

    public override void setValue(object value) {
        this.value = (Vector2) value;
        Mark();
    }

    public void Mark() {
        up.GetComponent<Image>().color = Color.white;
        right.GetComponent<Image>().color = Color.white;
        down.GetComponent<Image>().color = Color.white;
        left.GetComponent<Image>().color = Color.white;
        if(value.Equals(new Vector2(0, -1))) up.GetComponent<Image>().color = color;
        if(value.Equals(new Vector2(1,  0))) right.GetComponent<Image>().color = color;
        if(value.Equals(new Vector2(0,  1))) down.GetComponent<Image>().color = color;
        if(value.Equals(new Vector2(-1, 0))) left.GetComponent<Image>().color = color;
    }
}