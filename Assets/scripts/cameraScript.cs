using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	public GameObject ball;
	public GameObject pota;

	void Start(){
	}

	IEnumerator StartLoader () {
		yield return new WaitForSeconds(500);
	}

	void Update () {

		if (ball.transform.position.y < 1.2) {
			transform.position = new Vector3 (ball.transform.position.x + 0.8f, ball.transform.position.y + 0.3f, ball.transform.position.z);
			transform.LookAt (pota.transform.position);
		} else {
			transform.position = Vector3.Lerp(this.transform.position, new Vector3(pota.transform.position.x + 4.0f,pota.transform.position.y + 4.0f ,pota.transform.position.z), 0.02f);
			transform.LookAt (pota.transform.position);
			//StartCoroutine ("StartLoader");

		}

		if (Input.GetKeyDown (KeyCode.Space )){
			Vector3 cameraPos = transform.position;
			Vector3 ballPos = ball.transform.position;
			cameraPos.y = cameraPos.y - 0.2f;
			ballPos.y = ballPos.y - 0.3f;
			ball.transform.position = ballPos;
			transform.position = cameraPos;
		} 
	}
}
