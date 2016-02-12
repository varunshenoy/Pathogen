using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    
    public Transform target;
    public float m_speed;
    Camera mycam;
	public Texture2D cursorTexture;
	private Vector2 hotSpot = Vector2.zero;
    

    void Start () {
        
		//custom cursor, if wanted
		Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        mycam = GetComponent<Camera> ();
		//set ortho size
		var size = 3f;
		mycam.orthographicSize = size;
    } 
    
    void Update () {
        if (target) {
               
			//follow target using linear interpolation
            transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3(0, 0, -10);
            
        }
        
    }
    
}