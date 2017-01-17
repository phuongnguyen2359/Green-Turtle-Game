using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler {
	private Text scoreReference;
	public static GameObject bin;

	void Start()
	{
		scoreReference = GameObject.Find("ScoreTextGUI").GetComponent<Text>();
		bin = gameObject;
	}

    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            DragHandler.itemBeingDragged.transform.SetParent(transform);
			scoreReference.text = (int.Parse(scoreReference.text) + 1).ToString();

			DragHandler.itemBeingDragged.GetComponent<CanvasRenderer> ().SetAlpha (0f);
			Destroy (DragHandler.itemBeingDragged);
        }
    }
}
