using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
	Vector2 MousePosition;
	Camera Camera;


	coin coinsManager;

	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public CircleCollider2D col;
	
	


	[HideInInspector] public Vector3 pos { get { return transform.position; } }

	public GameObject GameOver;
	public GameObject Pannel;
	public GameObject wall;
	//public GameObject wall_right;
	

	//------coin managing-------------------------
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<CircleCollider2D>();
	}

	

	void Start()
    {
		//Camera = GameObject.Find("Camera").GetComponent<Camera>();
		
	}


    //void Update()
    //{/
      //if(Input.GetMouseButtonDown(0))
        //{
	//		MousePosition = Input.mousePosition;
	//		MousePosition = Camera.ScreenToWorldPoint(MousePosition);

	//		Debug.Log(MousePosition);
      //  }
   // }

    // OnTriggerEnter2D�� �浹�� �Ͼ�� �ѹ��� ȣ��Ǵ� �Լ�

    public int Coin = 0;
	public int ScoreCount = 0;
	

	public TextMeshProUGUI textCoins;
	public TextMeshProUGUI textScoreCounts;

	void Update()
    {
		//highscore, coin are recoreded
		PlayerPrefs.SetInt("HighScore", ScoreCount);
		PlayerPrefs.SetInt("HighCoin", Coin);

	}



	private void OnTriggerEnter2D(Collider2D other)
	{
		



		if (other.transform.tag == "coin")
		{
			Coin++;
			textCoins.text = Coin.ToString();
			Destroy(other.gameObject);

		}
		
		if (other.transform.tag == "SC")
		{
			
			//ScoreCount++;
			ScoreCount += 2;
			textScoreCounts.text = ScoreCount.ToString();
			Debug.Log("score!!!");
			
		}


	}

    private void OnCollisionEnter2D(Collision2D colli)
    {
        if(colli.gameObject.tag =="GameOver")
        {
			Debug.Log("GAMEOVER");

			

			SceneManager.LoadScene("Gameover");

			Pannel.SetActive(true);
			//�ð��� �����
			Time.timeScale = 0.0f;
			
		}

		//���� ���� �ε������� �ڵ��� ���� �︮�� �Լ�
		if (colli.transform.tag == "wall")
		{
			Handheld.Vibrate();
			Debug.Log("vibration");

		}
	}


    //end coin managing-------------------------------



    public void Push(Vector2 force)
	{
		rb.AddForce(force, ForceMode2D.Impulse);
	}

	public void ActivateRb()
	{
		rb.isKinematic = false;
	}

	public void DesactivateRb()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
		rb.isKinematic = true;
	}







	
}