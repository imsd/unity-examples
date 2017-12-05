using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateStats : MonoBehaviour {

	// assign the game objects that will be animated
	public Transform Shape1;
	public Transform Shape2;
	public Transform Shape3;

	// beginning property for shapes
	public Vector3 startingValue;

	// ending properties for shapes
	public Vector3 TargetValue1;
	public Vector3 TargetValue2;
	public Vector3 TargetValue3;

	// keep track of time
	private float StartTime;
	public float AnimationLength = 3f;

	// text object
	public TextMesh DisplayText;

	// Use this for initialization
	void Start () {

		// start the timer
		StartTime = 0f;
		
		// as an alternative to assigning in the inspector,
		// assign by finding names of game objects
		Shape1 = GameObject.Find ("Shape (1)").transform;
		Shape2 = GameObject.Find ("Shape (2)").transform;
		Shape3 = GameObject.Find ("Shape (3)").transform;

		DisplayText = GameObject.Find ("Display Text").GetComponent<TextMesh>();

		// set all scales to starting value
		Shape1.transform.localScale = startingValue;
		Shape2.transform.localScale = startingValue;
		Shape3.transform.localScale = startingValue;
		
	}
	
	// Update is called once per frame
	void Update () {

		// how much time has passed since the start of the animation
		float TimePassed = (Time.time - StartTime);

		// what total is that as a proportion?
		float Proportion = TimePassed / AnimationLength;

		// animate using "Lerp" function which moves between two values smoothly
		Shape1.transform.localScale = Vector3.Lerp (startingValue, TargetValue1, Proportion);
		Shape2.transform.localScale = Vector3.Lerp (startingValue, TargetValue2, Proportion);
		Shape3.transform.localScale = Vector3.Lerp (startingValue, TargetValue3, Proportion);

		// do something with the text display
		// convert the Proportion (zero to one) to a percentage (0 to 100)
		int Percentage = (int)Mathf.Round((Proportion * 100));
		// clamp it so it doesnt exceed 100
		Percentage = Mathf.Clamp (Percentage, 0, 100);
		// add a % symbol on the end
		string PercentageString = Percentage.ToString() + "%";
		// set the display text to that value
		DisplayText.text = PercentageString;
	}
}
