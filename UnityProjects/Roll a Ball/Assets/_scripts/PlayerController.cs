using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	#region variables
	public float thrust;
	public float friction;
	private Rigidbody rb;
	public int score;
	public Text scoreText;
    public Slider scoreSlider;
    public Transform nextLevelButton;
    public Transform quitButton;
    public Text nextLevelButtonText;
    public Text quitButtonText;
	#endregion

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		rb.drag = friction;
		score = 0;
		SetScoreText ();
        //set the buttons to a deactivated state with no text
        nextLevelButtonText.text = "";
        quitButtonText.text = "";
        nextLevelButton.GetComponent<Button>().interactable = false;
        quitButton.GetComponent<Button>().interactable = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement*thrust);

        if (Input.GetKeyDown("escape"))
        {
            QuitGame();
        }
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
        scoreSlider.value = score;

        if (score >= scoreSlider.maxValue)
        {
            nextLevelButtonText.text = "GO TO NEXT LEVEL";
            quitButtonText.text = "QUIT";
            nextLevelButton.GetComponent<Button>().interactable = true;
            quitButton.GetComponent<Button>().interactable = true;
        }
	}

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoTo_NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
