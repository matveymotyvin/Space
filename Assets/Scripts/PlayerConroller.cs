using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}
public class PlayerConroller : MonoBehaviour
{
	public float Speed = 10;
	public float tilt;
	private Rigidbody m_rigidbody;
	public Boundary boundary;

	public GameObject shot;
	public Transform[] shotSpawns;

	public float fireRate = 0.5f;
	public float nextFire = 0.0f;

    public void Update()
    {
		if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
			nextFire = Time.time + fireRate;
			foreach (var shotSpawn in shotSpawns)
			{
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
			GetComponent<AudioSource>().Play();
		}
		
    }
    void Start()
	{
		m_rigidbody = GetComponent<Rigidbody>();
	}
		private void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		m_rigidbody.velocity = movement * Speed;

		m_rigidbody.position = new Vector3
		(
			Mathf.Clamp(m_rigidbody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(m_rigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		m_rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, m_rigidbody.velocity.x * -tilt);
	}
	
	
}