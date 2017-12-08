using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	//class PointerController extends MonoBehaviour implements 
	//IPointerDownHandler, IPointerUpHandler


	private  bool pressed;    
	public void OnPointerUp (PointerEventData eventData) {
		//Debug.Log (eventData); ⇐ for testing!!!!
		pressed = false;
	}


	public void OnPointerDown (PointerEventData eventData) {
		//Debug.Log (eventData);  ⇐ for testing!!!!
		pressed = true;
	}
	public bool getPressed() {
		return pressed;
	}

}
