using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickForce : MonoBehaviour {

	public float _kickForce = 30.0f;

	public float _kickXAngle = 45.0f;

	public float _kickYAngle = 0.0f;

	private Vector3 _oldPos;

	private Vector3 _heading = Vector3.zero;

	private float _kickCooldown = 0.2f;

	private bool _canKick = true;

	public AudioClip _kickSound;

	private AudioSource _audioSource;

	void OnCollisionEnter(Collision collision)	{
		if(collision.collider.tag == "Ball" && _canKick)
		{
			_canKick = false;
			_audioSource.pitch = Random.Range(0.75f, 1.25f);
			_audioSource.PlayOneShot(_kickSound);
			collision.collider.gameObject.GetComponent<Rigidbody>().AddForce((Quaternion.AngleAxis(_kickXAngle, Vector3.right) * _heading.normalized) * _kickForce);
			StartCoroutine(EnableKickAfterTime(_kickCooldown));
		}
		
	}
	void Start()
	{
		_oldPos = transform.position;
		_audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		
		_heading = transform.gameObject.transform.position - _oldPos;
		_oldPos = transform.position;
	}

	IEnumerator EnableKickAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
		_canKick = true;
	}
}
