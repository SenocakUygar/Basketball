
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ballScript : MonoBehaviour {

	public Image zeiger;
	public Image innere;
	public float jump;
	public Image computerIsDran;
	public Image spielerIsDran;
	float boolTime = 0;
	private bool kont;
	private bool playerKont;
	private GameObject pota;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		jump = 1.0f;
		kont = true;
		playerKont = true;
		pota = GameObject.Find("BasketballHoop");
		rb = GetComponent<Rigidbody> ();
		spielerIsDran.enabled = true;
		computerIsDran.enabled = false;
	}

	IEnumerator KiBerechnung () {

		yield return new WaitForSeconds(5);
		if (!playerKont) {
			rb.isKinematic = false;
			Vector3 dir = pota.transform.position - transform.position;
			dir.y = 0f;
			float entfernung = dir.magnitude;
			jump = 0.3015370723640391f * entfernung + 4.596207675781742f;
			berechneKraftAndWerfe(jump);

			jump = 1.0f;
			boolTime = Time.time;
			kont = false;
			playerKont = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < 1 && Time.time - boolTime > 3f && !kont) {
			float x = Random.Range (1, 7);
			float z = Random.Range (-6, 6);
			//-5, 1, 0
			Vector3 pos = new Vector3 (x * -1, 1, z);
			transform.position = pos;
			transform.rotation = Quaternion.Euler (0, 0, 0);
			jump = 1.0f;
			innere.transform.localScale = new Vector3(0f, 1f, 1f);
			kont = true;
			rb.isKinematic = true;
			if (playerKont) {
				spielerIsDran.enabled = true;
				computerIsDran.enabled = false;
			} else {
				spielerIsDran.enabled = false;
				computerIsDran.enabled = true;
			}
		}

		if (playerKont) {
			
			Vector3 dir = pota.transform.position - transform.position;
			dir.y = 0f;
			float entfernung = dir.magnitude;
			float perfectValue = 0.3015370723640391f * entfernung + 4.596207675781742f;
			float xPosNorm = (perfectValue-1f)/(10f);
			zeiger.GetComponent<RectTransform>().anchoredPosition = new Vector3(xPosNorm * 144f, 0f, 0f);

			if (Input.GetButton ("Jump")) {

				jump += 4f * Time.deltaTime;
				if (jump > 10)
					jump = 10;
				float f = (jump - 1f) /10f;
				f = Mathf.Clamp01( f );
				innere.transform.localScale = new Vector3(f, 1f, 1f);
			} 

			if (Input.GetKeyUp (KeyCode.Space)) {
				rb.isKinematic = false;
				berechneKraftAndWerfe (jump);
				jump = 1.0f;
				boolTime = Time.time;
				kont = false;
				playerKont = false;
			}

		} else {
			StartCoroutine ("KiBerechnung");
		}


	}

	private void berechneKraftAndWerfe(float wieViel)
	{
		Vector3 force = new Vector3(jump * -1, jump, 0f);
		Vector3 dir = pota.transform.position - transform.position;
		dir.y = 0f;
		dir.Normalize();
		float angle = Mathf.Acos(Vector3.Dot(dir, Vector3.left))*Mathf.Rad2Deg;
		if (transform.position.z > 0) {
			angle *= -1;
		} 
		force = Quaternion.AngleAxis(angle, Vector3.up) * force; 

		rb.AddForceAtPosition (force, pota.transform.position ,ForceMode.Impulse);
	}

	public bool isSpielerDran(){
		return !playerKont;
	}

}
