using UnityEngine;
using System.Collections;

public class TouchArea : MonoBehaviour {

    public Color defaultColour;
    public Color selectedColour;
    public Color thirdColor;
    private SpriteRenderer spriteRen;

    void Start() {
        spriteRen = GetComponent<SpriteRenderer>();
    }

    public void OnTouchDown() {
        Debug.Log("OnTouchDown");
        spriteRen.color = selectedColour;
    }

    public void OnTouchUp() {
        Debug.Log("OnTouchUp");
        spriteRen.color = defaultColour;
    }

    public void OnTouchStay() {
        Debug.Log("OnTouchStay");
        spriteRen.color = selectedColour;
    }

    public void OnTouchExit() {
        Debug.Log("OnTouchExit");
        spriteRen.color = defaultColour;
    }

    public void ButtonPress() {
        Debug.Log("OnTouchButtonPress");
        spriteRen.color = thirdColor;
    }
}
