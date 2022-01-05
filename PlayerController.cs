using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

	private Rigidbody rb;
	private int count;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;

		SetCountText();
		winTextObject.SetActive(false);
	}

	void SetCountText()
	{
		countText.text = "Count : " + count.ToString();

		if(count >= 14)
		{
			winTextObject.SetActive(true);
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;

			SetCountText();
		}
	}
}