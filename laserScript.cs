// создаем ленту лазера
using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	public Transform startPoint;
	public Transform endPoint;
	LineRenderer laserLine;
	// Use this for initialization
	void Start () {
		laserLine = GetComponentInChildren<LineRenderer> (); 
		laserLine.SetWidth (.1f, .1f);
	}
	
	// Update is called once per frame
	void Update () {
      //s  laserLine.transform.Rotate(60,0,0);
		laserLine.SetPosition (0, startPoint.position);
		laserLine.SetPosition (1, endPoint.position);
        


    }
}
