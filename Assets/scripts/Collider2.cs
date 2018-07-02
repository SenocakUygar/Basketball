using UnityEngine;
using System.Collections;

public class Collider2 : MonoBehaviour {

	private bool colliderKont;
	private float colliderTime;

	// Use this for initialization
	void Start () {
		colliderKont = false;
		colliderTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - colliderTime > 5f)
			colliderKont = false;
	
	}

	void OnTriggerEnter(Collider other) {
		colliderKont = true;
		colliderTime = Time.time;
	}

	public bool getColliderKont()
	{
		return colliderKont;
	}
	public void setColliderKont()
	{
		colliderKont = false;
	}

}
