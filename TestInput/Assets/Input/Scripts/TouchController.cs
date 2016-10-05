using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {
	
	private Touch touch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 point = touch.position;
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay( point );
		if ( Physics.Raycast( ray, out hit ) ) 
		{
			hit.transform.gameObject.SendMessage( "OnMouseDown" );
		}
	}


}
