using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class test : MonoBehaviour {
	private GameObject block;
	private CircleCollider2D ObjCol2D;
	static Vector2 firstPressPos;
	static Vector2 secondPressPos;
	private int SwipeCount = 0;
	private Text score;
	public int RequiredScore;

	public Sprite dirtSprite4;
	public Sprite dirtSprite3;
	public Sprite dirtSprite2;
	public Sprite dirtSprite1;

	private bool HitReg = false;

//	static bool GetMouseInput()
//	{
//		if (Input.GetMouseButtonDown(0))
//		{
//			firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
//			return true;
//		}
//		else if (Input.GetMouseButtonUp(0))
//		{
//			secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
//			return true;
//		}
//
//		return false;
//	}

	private bool IfLinePassObj(Vector2 LineStart, Vector2 LineEnd, Vector2 ObjectCoords, float offset) {
		float MaxX, MaxY, MinX, MinY;
		bool PassX = false;
		bool PassY = false;

		if (LineStart.x > LineEnd.x) {
			MaxX = LineStart.x;
			MinX = LineEnd.x;
		} else {
			MaxX = LineEnd.x;
			MinX = LineStart.x;
		}

		if (LineStart.y > LineEnd.y) {
			MaxY = LineStart.y;
			MinY = LineEnd.y;
		} else {
			MaxY = LineEnd.y;
			MinY = LineStart.y;
		}

		if (ObjectCoords.x < MaxX && ObjectCoords.x > MinX) {
			PassX = true;
//			Debug.Log ("X not need offset");
		} else if (ObjectCoords.x > MaxX) {
			if (ObjectCoords.x - MaxX < offset) {
				PassX = true;
//				Debug.Log ("X - offset");
			}
		} else if (ObjectCoords.x < MinX) {
			if (MinX - ObjectCoords.x < offset) {
				PassX = true;
//				Debug.Log ("X + offset");
			}
		}

		if (ObjectCoords.y < MaxY && ObjectCoords.y > MinY) {
			PassY = true;
//			Debug.Log ("Y not need offset");
		} else if (ObjectCoords.y > MaxY) {
			if (ObjectCoords.y - MaxY < offset) {
				PassY = true;
//				Debug.Log ("Y - offset");
			}
		} else if (ObjectCoords.y < MinY) {
			if (MinY - ObjectCoords.y < offset) {
				PassY = true;
//				Debug.Log ("Y + offset");
			}
		}

		if (PassX && PassY) {
			return true;
		} else
			return false;
	}
		
	public static bool IfMouseHitObject(Vector2 MousePos, GameObject Object, float offset) {
		bool PassX = false;
		bool PassY = false;

		float ObjectX = Object.transform.position.x;
		float ObjectY = Object.transform.position.y;

		if (ObjectX == MousePos.x) {
			PassX = true;
//			Debug.Log ("Obj X not need offset");
		} else if (ObjectX > MousePos.x) {
			if (ObjectX - MousePos.x < offset) {
				PassX = true;
//				Debug.Log ("Obj X - offset");
			}
		} else if (ObjectX < MousePos.x) {
			if (MousePos.x - ObjectX < offset) {
				PassX = true;
//				Debug.Log ("Obj X + offset");
			}
		}

		if (ObjectY == MousePos.y) {
			PassY = true;
//			Debug.Log ("Obj Y not need offset");
		} else if (ObjectY > MousePos.y) {
			if (ObjectY - MousePos.y < offset) {
				PassY = true;
//				Debug.Log ("Obj Y - offset");
			}
		} else if (ObjectY < MousePos.y) {
			if (MousePos.y - ObjectY < offset) {
				PassY = true;
//				Debug.Log ("Obj Y + offset");
			}
		}

		if (PassX && PassY) {
			return true;
		} else
			return false;
	}

	// Use this for initialization
	void Start () {
		block = gameObject;
		ObjCol2D = block.GetComponent<CircleCollider2D> ();

		score = GameObject.Find("ScoreTextGUI").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			// Mouse 1 being held
			if (IfMouseHitObject (Input.mousePosition, block, ObjCol2D.radius) && !HitReg) {
				// Mouse hit Object
				if (int.Parse(score.text) == RequiredScore) {
					HitReg = true;
					SwipeCount++;
				}
			} else if (!IfMouseHitObject(Input.mousePosition, block, ObjCol2D.radius))
				// Only revert until mouse drags out of object
				HitReg = false;
			
		}
		if (Input.GetMouseButtonDown(0))
		{
			firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		}
		else if (Input.GetMouseButtonUp(0))
		{
			secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		}

//        if (SwipeManager.IsSwipingLeft())
//        {
//            print("Swiping Left");
//        }
//        else if (SwipeManager.IsSwipingUp())
//        {
//            print("Swiping Up");
//        }
//        else if (SwipeManager.IsSwipingRight())
//        {
//            print("Swiping Right");
//        }
//        else if (SwipeManager.IsSwipingDown())
//        {
//            print("Swiping Down");
//        }
//        else if (SwipeManager.IsSwipingUpLeft())
//        {
//            print("Swiping Up Left");
//        }
//        else if (SwipeManager.IsSwipingDownLeft())
//        {
//            print("Swiping Down Left");
//        }
//        else if (SwipeManager.IsSwipingUpRight())
//        {
//            print("Swiping Up Right");
//        }
//        else if (SwipeManager.IsSwipingDownRight())
//        {
//            print("Swiping Down Right");
//        }
		if (SwipeManager.IsSwiping) {
//			RaycastHit2D hit = Physics2D.Raycast (firstPressPos, secondPressPos);
//			print (hit.collider);
//			print ("First Press: " + firstPressPos);
//			print ("Second Press: " + secondPressPos);
//			print ("Obj Pos: " + block.transform.position);
//			print ("Bounds Size /2: " + block.GetComponent<CircleCollider2D>().radius);
//			if (IfLinePassObj(firstPressPos, secondPressPos, block.transform.position, ObjCol2D.radius)) {
//				SwipeCount++;
//				print ("Swiped " + SwipeCount);
//			}
		}
//		if (Input.touches [0].phase == TouchPhase.Moved) {
//			RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector2.up);
//			if (hit.collider != null) {
//				//			float distance = Mathf.Abs(hit.point.y - transform.position.y);
//				//			float heightError = floatHeight - distance;
//				//			float force = liftForce * heightError - rb2D.velocity.y * damping;
//				//			rb2D.AddForce(Vector3.up * force);
//				SwipeCount++;
//			}
//		}
//		switch (SwipeCount) {
//			case (1):
//				block.GetComponent<MeshRenderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 0.8f);
//				block.GetComponent<CanvasRenderer> ().SetAlpha (0.8f);
//				break;
//			case (2):
//				block.GetComponent<MeshRenderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 0.6f);
//				block.GetComponent<CanvasRenderer> ().SetAlpha (0.6f);
//				break;
//			case (3):
//				block.GetComponent<MeshRenderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 0.4f);
//				block.GetComponent<CanvasRenderer> ().SetAlpha (0.4f);
//				break;
//			case (4):
//				block.GetComponent<MeshRenderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 0.2f);
//				block.GetComponent<CanvasRenderer> ().SetAlpha (0.2f);
//				break;
//			case (5):
//				block.GetComponent<MeshRenderer> ().material.color = new Color (1.0f, 1.0f, 1.0f, 0f);
//				block.GetComponent<CanvasRenderer> ().SetAlpha (0f);
//				Destroy (block);
//				break;
//		}

		switch (SwipeCount) {
			case (1):
			GetComponent<Image> ().sprite = dirtSprite4;
			break;
			case (2):
			GetComponent<Image> ().sprite = dirtSprite3;
			break;
			case (3):
			GetComponent<Image> ().sprite = dirtSprite2;
			break;
			case (4):
			GetComponent<Image> ().sprite = dirtSprite1;
			break;
			case (5):
			Destroy (block);
			break;
		}
    }
}
