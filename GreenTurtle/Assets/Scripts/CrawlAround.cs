using UnityEngine;
using System.Collections;

public class CrawlAround : MonoBehaviour {
	private int ScreenW;
	private int ScreenH;
	private float ObjRadius;

	private GameObject Object;
	private Vector3 newDestination;
	private Vector3 velocity;
	public float TimeToReach;
	private float timeToChangeDestination;

	// Use this for initialization
	void Start () {
		Object = gameObject;
		ScreenW = Screen.width;
		ScreenH = Screen.height;

//		Debug.Log ("Screen: " + ScreenW + " x " + ScreenH);

		ObjRadius = Object.GetComponent<CircleCollider2D> ().radius;
	}
	
	// Update is called once per frame
	void Update() {
		if (timeToChangeDestination <= 0) {
			timeToChangeDestination = TimeToReach;
			newDestination = new Vector3 (Random.Range (0, ScreenW), Random.Range (0, ScreenH), transform.position.z);
//			Debug.Log ("new D: " + newDestination);
			Vector2 tempPos = transform.position;
//			Debug.Log ("Reset! Time until change: " + timeToChangeDestination);
		}
//		Debug.Log ("tempPos X before: " + tempPos.x);
//		Debug.Log ("tempPos Y before: " + tempPos.y);
//		Debug.Log("position: " + transform.position);

//		transform.position = Vector2.MoveTowards (transform.position, newDestination, Speed);

		if (DragHandler.itemBeingDragged != Object) {
			RotateToPoint (newDestination);

			// Smoothly move towards the next destination
			transform.position = Vector3.SmoothDamp (transform.position, newDestination, ref velocity, TimeToReach);
		}
//		Debug.Log ("position: " + transform.position);
		timeToChangeDestination -= Time.deltaTime;
	}

	void RotateToPoint(Vector3 destination) {
		// Code for rotating towards next destination
		Vector3 vectorToTarget = destination - transform.position;
		float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 90;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * 5f);
	}
}
