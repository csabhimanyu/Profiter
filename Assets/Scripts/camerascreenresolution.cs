using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascreenresolution : MonoBehaviour {
    public bool maintainWidth = true;
    float defaultWidth;
    float defaultHeight; 

    [Range(-1, 1)]
    public int adaptPosition;

    Vector3 CameraPos; 

	// Use this for initialization
	void Start () {
        CameraPos = Camera.main.transform.position;

        defaultHeight = Camera.main.orthographicSize; 
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (maintainWidth) {
            Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;
            Camera.main.transform.position = new Vector3(CameraPos.x, CameraPos.y + adaptPosition * (defaultHeight - Camera.main.orthographicSize), CameraPos.z);
        } else {
            Camera.main.transform.position = new Vector3(CameraPos.x + adaptPosition * (defaultWidth - Camera.main.orthographicSize * Camera.main.aspect), CameraPos.y, CameraPos.z);
        }
	}
}
