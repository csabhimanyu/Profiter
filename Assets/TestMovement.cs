using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour {

    public Transform[] path;
    public float speed;
    int indx;

    private void Start()
    {
        indx = 0;
        Move();
    }
    // Use this for initialization
    void Move()
    {

       
            iTween.MoveTo(this.gameObject, iTween.Hash("path", path, "time", speed,"islocal",true,  "easetype", iTween.EaseType.easeInOutSine,"oncomplete", "OnComplete"));






    }

    void OnComplete()
    {
        transform.GetChild(0).GetComponent<TrailRenderer>().Clear();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
