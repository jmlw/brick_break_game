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

    void OnTouchDown() {

        spriteRen.color = selectedColour;
    }

    void OnTouchUp() {

        spriteRen.color = defaultColour;
    }

    void OnTouchStay() {

        spriteRen.color = selectedColour;
    }

    void OnTouchExit() {

        spriteRen.color = defaultColour;
    }

    public void ButtonPress() {
        spriteRen.color = thirdColor;
    }
}
