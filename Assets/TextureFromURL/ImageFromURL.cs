using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFromURL : MonoBehaviour {

	public string url = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";


	// because of the "yield" command we cant run this as "void"
	// but rather as IEnumerator, which basically allows the function
	// to run on its own timeline, otherwise while the image
	// is downloading it would block all other functions and your program
	// would momentarily pause for download

	IEnumerator Start () {

		// www is a class that lets you load in a URL
		WWW www = new WWW(url);

		// this means "wait until this has loaded until continuing"
		yield return www;

		// get the renderer component
		Renderer renderer = GetComponent<Renderer>();

		// put the texture in, boom
		renderer.material.mainTexture = www.texture;

	}
}