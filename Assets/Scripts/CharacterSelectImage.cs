using UnityEngine;

public class CharacterSelectImage : MonoBehaviour {

	public Vector3 target;

	public void SlideTo(Vector3 position) {
		target = position;
	}

	public void JumpTo(Vector3 position) {
		target = position;
		transform.position = position;
	}

	// Use this for initialization
	void Start () {
		target = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime*4);
	}
}
