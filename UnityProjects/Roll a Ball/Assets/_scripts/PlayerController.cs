using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	#region variables
	public float thrust;
	public float friction;
	private Rigidbody rb;
	private int score;
	public Text scoreText;
	public Text winMessage;
	#endregion

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		rb.drag = friction;
		score = 0;
		SetScoreText ();
		winMessage.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement*thrust);
	}

	void OnTriggerEnter(Collider other) 
	{
		//Destroy(other.gameObject);
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive (false);
			score++;
			SetScoreText ();
		}
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString ();
		if (score >= 15) 
		{
			winMessage.text = "WINNER, WINNER, CHICKEN DINNER!!";
		}
	}
}
