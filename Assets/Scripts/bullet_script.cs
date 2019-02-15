using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
	public Rigidbody rb;
	public float bullet_speed;
	private float life;

	void Start()
	{
		life = 1;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		rb.velocity = -transform.up * Time.deltaTime * bullet_speed;
		life = life - (1 * Time.deltaTime);
		if ( life < 0 )
		{
			Destroy( gameObject );
			Debug.Log( "timeout" );
		}
    }

	void OnTriggerEnter( Collider other )
	{
		if ( other.tag != "bullet" ) 
		{	
			Destroy( gameObject );
	
		}
	}
}
