using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONarray : MonoBehaviour {

	public string url = "https://s3-us-west-1.amazonaws.com/riot-developer-portal/seed-data/matches1.json";

	// Use this for initialization
	IEnumerator Start () {
		
		// fetch the actual info, like you would from a browser
		WWW www = new WWW(url);

		// yield return waits for the download to complete before proceeding
		// but since this is in IEnumerator it wont stall the program outright
		yield return www;

		// use a JSON Object to store the info temporarily
		// this makes it easy to access the data struture
		JSONObject tempData = new JSONObject (www.text);

		// this particular API stores all the data under the header
		// "consolidated_weather" so first get in there
		JSONObject matches = tempData["matches"];

		// matches is a json object array of 100 members (i can see this
		// by just looking at it in firefox)
		// so we need to loop thru all those matches to extract relevant data
		for (int i = 0; i < 100; i++) {

			// then it looks like inside of each matches member there's
			// a 'participants' object we need to access
			JSONObject participants = matches[i]["participants"];

			// and participants itself is an array of further json objects
			// 0->9, each player in the game
			for (int n = 0; n < 10; n++) {
				JSONObject hero = participants[n]["championId"];

				// prints out each instance of each hero ID that is used
				Debug.Log (hero.ToString ());
			}

		}

	}

}
