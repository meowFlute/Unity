using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
    public float rotateSpeed;
	private Vector3 offsetValue;

	// Use this for initialization
	void Start () {
		offsetValue = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame but happens after everything else
	void LateUpdate () {
		transform.position = player.transform.position + offsetValue;
	}
}
