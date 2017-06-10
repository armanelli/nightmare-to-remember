using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorMovimento : MonoBehaviour {

	Rigidbody2D rigidbody;
	Animator anim;

	// Use this for initialization
	void Start () {

		rigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 mov_vector = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));

        if(mov_vector != Vector2.zero)
        {
            anim.SetBool("Andando", true);
            anim.SetFloat("input_x", mov_vector.x);
            anim.SetFloat("input_y", mov_vector.y);
        }
        else
        {
            anim.SetBool("Andando", false);
        }

        rigidbody.MovePosition(rigidbody.position + mov_vector * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider2D other)
    {
        switch (other.tag) {
            case "Zumbi":



                break;
        }
    }
}
