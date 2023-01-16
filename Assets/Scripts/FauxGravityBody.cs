using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour {

	private FauxGravityAttractor attractor;
	private Rigidbody rb;

	public bool placeOnSurface = false;

	void Start ()
	{
		rb = this.GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotation;
		rb.useGravity = false;
		attractor = FauxGravityAttractor.instance;
	}
	
	void FixedUpdate ()
	{
		if (placeOnSurface)
			attractor.PlaceOnSurface(rb);
		else
			attractor.Attract(rb);
	}

}
