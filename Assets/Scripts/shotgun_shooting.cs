using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

public class shotgun_shooting : MonoBehaviour, Gun
{
	public GameObject 	bullet;
	public int			bulletsPerShot;
	public int 			bullet_speed;
	public float     	reload_time;
	public AudioClip 	gunshot;
	public AudioClip    reload;
	public AudioClip 	out_of_ammo;
	public AudioSource  gunshot_source;
	public AudioSource  reload_source;
	public AudioSource  out_of_ammo_source;
	
	public float spreadAngle;
	private List<Quaternion> bullets;

	void Start()
	{
		gunshot_source.clip = gunshot;
		reload_source.clip = reload;
		bullets = new List<Quaternion>(bulletsPerShot);
		for (int i = 0; i < bulletsPerShot; i++)
		{
			bullets.Add(Quaternion.Euler(Vector3.zero));
		}
	}

	public void Fire()
	{
		for (int i = 0; i < bulletsPerShot; i++)
        {
            bullets[i] = Random.rotation;
            GameObject p = Instantiate(bullet, transform.position, transform.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, bullets[i], spreadAngle);
            //p.GetComponent<Rigidbody>().AddForce(p.transform.right * bullet_speed);
            //i++;
        }
		gunshot_source.Play();
		
	}

	public void OutOfAmmo()
	{
		out_of_ammo_source.Play();
	}

	public void Reload()
	{
		reload_source.Play();
	}

//    public int pelletCount;
//    public float spreadAngle;
//    public float pelletFireVel;
//    public GameObject pellet;
//    private List<Quaternion> pellets;
//    
//
//    private void Awake()
//    {
//        pellets = new List<Quaternion>(pelletCount);
//        for (int i = 0; i < pelletCount; i++)
//        {
//            pellets.Add(Quaternion.Euler(Vector3.zero));
//        }
//    }
//
//    private void Update()
//    {
//        if (Input.GetButtonDown("Fire1"))
//        {
//            Fire();
//        }
//    }
//
//    public void Fire()
//    {
//        int i = 0;
//        foreach (Quaternion quat in pellets)
//        {
//            pellets[i] = Random.rotation;
//            GameObject p = Instantiate(pellet, transform.position, transform.rotation);
//            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
//            p.GetComponent<Rigidbody>().AddForce(p.transform.right * pelletFireVel);
//            i++;
//        }
//        
//    }
//
//    public void Reload()
//    {
//        
//    }
//
//    public void OutOfAmmo()
//    {
//        
//    }
}