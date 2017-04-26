using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingTextController : MonoBehaviour {

	[SerializeField]
	Vector3 motion;

	string word = "Undefined";

	// Use this for initialization
	void Start () {
		word = Words.words[Random.Range(0, Words.words.Length)];
		UpdateText();
	}
	
    void OnTriggerExit(Collider other) {
		Destroy(gameObject);
		SceneManager.LoadScene("Score");
    }

	void Update () {
		UpdateText();
		transform.position += motion*Time.deltaTime;
	}

	public bool CompleteInput(string input) {
		if (input != word) return false;

		Words.score += word.Length;
		Destroy(gameObject);
		return true;
	}

	void UpdateText() {
		string text;
		if (word.StartsWith(Words.input)) {
			text = "<color=\"orange\">" + Words.input + "</color>" + word.Substring(Words.input.Length);
		} else {
			text = word;
		}
		GetComponent<TextMesh>().text = text;
	}
}
