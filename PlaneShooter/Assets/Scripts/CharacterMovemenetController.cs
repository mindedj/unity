using UnityEngine;
using System.Collections;

public class CharacterMovemenetController : MonoBehaviour {

	private Rigidbody2D rb;
    
	public float horizontalSpeed = 2f;
    public float verticalSpeed = 2f;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
	
		float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxisRaw("Vertical");
		this.rb.velocity = new Vector2(moveH * horizontalSpeed, moveV * verticalSpeed);
		

	}
}
