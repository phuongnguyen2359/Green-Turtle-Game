using UnityEngine;
using System.Collections;

public class Wipe : MonoBehaviour {

	private GameObject SwipeObject;
	static Vector2 ObjectPos;
	private int WipeCount;

	private MeshRenderer ObjMRend;
	private CanvasRenderer ObjCRend;
	private CircleCollider2D ObjCol2D;

	static Vector2 initInputPos;
	static Vector2 dragPos;
	static Vector2 endInputPos;
//	private float offset = SwipeObject.GetComponent<Collider>().bounds.size.x/2;

//	static bool GetMouseInput() {
//		SwipeObject.GetComponent<MeshRenderer>().bounds.size.x
//		// Mouse Input also works for first Touch, but Touch Input doesn't also work for Mouse
//		// Need to detect when input changes direction
//		if (Input.GetMouseButtonDown(0))
//		{
//			// because Input.mousePosition is a Vector3
//			initInputPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
//			print ("Mouse Down!");
//		}
//		else if (Input.GetMouseButtonUp(0))
//		{
//			endInputPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
//			print ("Mouse Up!");
//			return true;
//		}
//	}

	// Need to do: Check if swipe change direction AND if swipe hit object
	void OnMouseDown() {
		initInputPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		dragPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		print("Mouse Down");
		Debug.Log ("Mouse Down!");
	}

	void OnMouseDrag() {

	}

	void OnMouseUp() {
		Debug.Log ("Mouse Up!");
		endInputPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		if (Physics2D.Linecast (initInputPos, endInputPos)) {
			ObjMRend.material.color = new Color (1.0f, 1.0f, 1.0f, 0.5f);
			ObjCRend.SetAlpha (0.1f);
			Debug.Log ("Linecast Hit");
		}
	}

//	private bool IfLineHitObj(Vector2 LineStart, Vector2 LineEnd, Vector2 ObjCoord, float offset) {
//		if (
//	}

	// Use this for initialization
	void Start () {
		SwipeObject = gameObject;
		ObjectPos = new Vector2(transform.position.x,transform.position.y);
		WipeCount = 0;
		ObjMRend = SwipeObject.GetComponent<MeshRenderer> ();
		ObjCRend = SwipeObject.GetComponent<CanvasRenderer>();
		ObjCol2D = SwipeObject.GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				Debug.Log ("Name = " + hit.collider.name);
				Debug.Log ("Tag = " + hit.collider.tag);
				Debug.Log ("Hit Point = " + hit.point);
				Debug.Log ("Object position = " + hit.collider.gameObject.transform.position);
				Debug.Log ("--------------");
			}
		}
	}
}
