using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour {

	[SerializeField]
	private bool _risingTile = false;
	public bool RisingTile{
		get{
			return _risingTile;
		}

		set{
			_risingTile = value;
		}
	}

	[SerializeField]
	private Vector3 _loweringVector = new Vector3(0f,-5f,0f);

	private Vector3 _loweredPosition;

	private Vector3 _raisedPostion;

	private Vector3 _targetPosition;

	private float _targetAlpha;

	private MeshRenderer _meshRenderer;

	private bool _blocked = false;

	public bool Blocked
	{
		get{
			return _blocked;
		}
		set
		{
			_blocked = value;
		}
	}

	void Start()
	{
		_raisedPostion = transform.position;
		_loweredPosition = _raisedPostion + _loweringVector;
		_meshRenderer = GetComponent<MeshRenderer>();
		if(_risingTile)
		{
			transform.position = _loweredPosition;
            Color color = _meshRenderer.material.color;
            color.a = 0.0f;
            _meshRenderer.material.color = color;
        }
    }

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			RaiseTile();
		}
		if(Input.GetKeyDown(KeyCode.V))
		{
			LowerTile();
		}
	}

	public void RaiseTile()
	{
		_targetPosition = _raisedPostion;
		_targetAlpha = 1f;
		StopAllCoroutines();
		StartCoroutine(ChangePositionAndAlpha());
	}

	public void LowerTile()
	{
		_targetPosition = _loweredPosition;
		_targetAlpha = 0f;
		StopAllCoroutines();
		StartCoroutine(ChangePositionAndAlpha());
	}

	IEnumerator ChangePositionAndAlpha()
	{
		float r = _meshRenderer.material.color.r;
		float g = _meshRenderer.material.color.g;
		float b = _meshRenderer.material.color.b;
		float a = _meshRenderer.material.color.a;
		float speed = Random.Range(3f, 10f);
		while((transform.position - _targetPosition).magnitude > 0.1f)
		{
			transform.position = Vector3.Lerp(transform.position, _targetPosition, speed * Time.deltaTime);
			a = Mathf.Lerp(a,_targetAlpha,speed * Time.deltaTime);
			_meshRenderer.material.color = new Color(r,g,b,a);
			yield return null;
		}
	}


	public virtual void MoveIntoTile(TileMover mover)
	{
		_blocked = true;
	}

	public FloorTile GetTile(Vector3 direction)
	{
		RaycastHit info;

		if(Physics.Raycast(transform.position + new Vector3(0f,0.2f,0f), direction, out info, 2.0f)){

			FloorTile tile = info.collider.gameObject.GetComponent<FloorTile>();
			if(!tile.Blocked){
				//tile.Blocked = true;
				_blocked = false;
				return info.collider.gameObject.GetComponent<FloorTile>();
			}
		}

		return null;
	}
}
