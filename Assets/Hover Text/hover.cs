using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour {

	public string HoverText;
	public TextMesh DisplayTextObject;

	void OnMouseEnter() {
		// switch the 3d text so that its text value
		// is now whatever text value this hover instance holds
		DisplayTextObject.text = HoverText;

		// show it
		DisplayTextObject.color = Color.white;
	}

	void OnMouseExit() {
		DisplayTextObject.color = new Color(0,0,0,0);
	}
}
