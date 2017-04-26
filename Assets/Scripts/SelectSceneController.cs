using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SelectSceneController : MonoBehaviour {

	[SerializeField]
	private GameObject characterSelectImagePrefab = null;
	
	[SerializeField]
	private Text characterSelectText = null;

	private GameObject[] selectObjects = null;

	[SerializeField]
	private CharacterManager characterManager = null;

	private Vector3 LEFT = new Vector3(-20, 0, 0);
	private Vector3 RIGHT = new Vector3(20, 0, 0);
	private Vector3 CENTER = Vector3.zero;

	[SerializeField]
	AudioClip inputAudio;

	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();

		selectObjects = new GameObject[characterManager.characters.Length];

		int i = 0;
		foreach (CharacterManager.Character character in characterManager.characters) {
			GameObject selectImage = Instantiate(characterSelectImagePrefab, LEFT, Quaternion.identity);
			SpriteRenderer renderer = selectImage.GetComponent<SpriteRenderer>();
			renderer.sprite = character.sprite;
			selectObjects[i] = selectImage;
			i++;
		}

		selectObjects[Words.selected].GetComponent<CharacterSelectImage>().JumpTo(CENTER);
		characterSelectText.text = characterManager.characters[Words.selected].name;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Horizontal")) {
			float d = Input.GetAxisRaw("Horizontal");
			if (d > 0) {
				selectObjects[Words.selected].GetComponent<CharacterSelectImage>().SlideTo(LEFT);
				int newSelected = Mod(Words.selected + 1, selectObjects.Length);
				selectObjects[newSelected].GetComponent<CharacterSelectImage>().JumpTo(RIGHT);
				selectObjects[newSelected].GetComponent<CharacterSelectImage>().SlideTo(CENTER);
				Words.selected = newSelected;
				characterSelectText.text = characterManager.characters[Words.selected].name;
				audioSource.PlayOneShot(inputAudio);
			} else if (d < 0) {
				selectObjects[Words.selected].GetComponent<CharacterSelectImage>().SlideTo(RIGHT);
				int newSelected = Mod(Words.selected - 1, selectObjects.Length);
				selectObjects[newSelected].GetComponent<CharacterSelectImage>().JumpTo(LEFT);
				selectObjects[newSelected].GetComponent<CharacterSelectImage>().SlideTo(CENTER);
				Words.selected = newSelected;
				characterSelectText.text = characterManager.characters[Words.selected].name;
				audioSource.PlayOneShot(inputAudio);
			}
		}

        if (Input.GetButtonDown("Submit")) {
			audioSource.PlayOneShot(inputAudio);
            SceneManager.LoadScene("Play");
        }
	}

	int Mod(int i, int n) {
		int r = i % n;
		return r < 0 ? r + n : r;
	}
}
