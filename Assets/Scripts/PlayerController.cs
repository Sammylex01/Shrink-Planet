using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Range(0, 15)]
	public float moveSpeed;

	[Range(50, 250)]
	public float rotationSpeed;

	[HideInInspector]
	public bool isDead;

	private float rotation;
	private Rigidbody rb;
	private float score;

	void Start ()
	{
		rb = this.GetComponent<Rigidbody>();
		isDead = false;
	}

	void Update ()
	{
		rotation = Input.GetAxisRaw("Horizontal");
		if(scoreText == null)
		     return;
		if(!isDead) {
			score = score + Time.deltaTime;
		}	 
	}

	void FixedUpdate ()
	{
		rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
		Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
		Quaternion deltaRotation = Quaternion.Euler(yRotation);
		Quaternion targetRotation = rb.rotation * deltaRotation;
		rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
		//transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
	}

}
