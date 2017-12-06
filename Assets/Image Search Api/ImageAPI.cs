using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAPI : MonoBehaviour {

	private string url = "https://api.qwant.com/api/search/images?count=10&offset=1&q=wutang";

	IEnumerator Start() {

		// so this particular API is fussy about being called from anything other than a browser
		// this next bit is a hack to make it think it's coming from a browser
		// notice the headers.add section. i didn't know how to do this til a few moments ago
		// so dont worry about it. just a rare case...
		// just notice the difference between this and the getWeather.cs script
		// but after WWW www = ... line it's the same
		var form = new WWWForm();
		var headers = new Hashtable();
		headers.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.12; rv:57.0) Gecko/20100101 Firefox/57.0");
		WWW www = new WWW(url, null, headers);


		yield return www;

		// log it to see whats up
		Debug.Log("1: " + www.text);
	
		// use a JSON Object to store the info temporarily
		// this makes it easy to access the data struture
		JSONObject tempData = new JSONObject (www.text);

		// log it just to see whats up
		Debug.Log ("2: " + tempData.ToString());

		// this particular API stores all the data under the header
		// "data" so first get in there
		JSONObject json_data = tempData["data"];

		// log it just to see whats up
		Debug.Log ("3: " + json_data.ToString());

		// and then within that, there's a child object "result"
		JSONObject json_result = json_data["result"];

		// and then within that, there's a child object "items"
		JSONObject json_items = json_result["items"];

		// log it just to see whats up
		Debug.Log ("4: " + json_items.ToString());

		// for this API, items is an array that contains a bunch of different images and associated Title,
		// thumbnail, description, etc etc (put the url into firefox and check it out)

		// item # 0 is just the first image in the array
		JSONObject json_firstimage = json_items[0];

		Debug.Log ("5: " + json_firstimage.ToString ());

		// finally, the actual JPG or PNG is stored in "media"
		JSONObject json_imageURL = json_firstimage["media"];

		Debug.Log ("6: " + json_imageURL.ToString());

		// for some reason, backslashes are getting introduced, probably in the string
		// conversion, so we have to remove them here...
		string imageURL = json_imageURL.ToString ().Replace(@"\", "");

		Debug.Log ("7: " + imageURL);

		// AND its putting quotes in front and back, so remove those...

		imageURL = imageURL.Replace ("\"", "");

		Debug.Log ("8: " + imageURL);


		// ... finally, time for the image! we have a clean URL
		// Start a download of the given URL
		WWW imageWWW = new WWW(imageURL);

		// Wait for download to complete
		yield return imageWWW;

		// assign texture
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = imageWWW.texture;

	}
}
