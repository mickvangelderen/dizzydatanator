using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSceneController : MonoBehaviour {

	[SerializeField]
	private GameObject characterSelectImagePrefab = null;

	[SerializeField]
	private Sprite[] sprites = null;

	private GameObject[] selectObjects = null;

	private Vector3 LEFT = new Vector3(-20, 0, 0);
	private Vector3 RIGHT = new Vector3(20, 0, 0);
	private Vector3 CENTER = Vector3.zero;

	// Use this for initialization
	void Start () {
		selectObjects = new GameObject[sprites.Length];

		Words.sprites = sprites;

		int i = 0;
		foreach (Sprite sprite in sprites) {
			GameObject selectImage = Instantiate(characterSelectImagePrefab, LEFT, Quaternion.identity);
			SpriteRenderer renderer = selectImage.GetComponent<SpriteRenderer>();
			renderer.sprite = sprite;
			selectObjects[i] = selectImage;
			i++;
		}

		selectObjects[Words.selected].GetComponent<CharacterSelectImage>().JumpTo(CENTER);
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
			} else if (d < 0) {
				selectObjects[Words.selected].GetComponent<CharacterSelectImage>().SlideTo(RIGHT);
				int newSelected = Mod(Words.selected - 1, selectObjects.Length);
				selectObjects[newSelected].GetComponent<CharacterSelectImage>().JumpTo(LEFT);
				selectObjects[newSelected].GetComponent<CharacterSelectImage>().SlideTo(CENTER);
				Words.selected = newSelected;
			}
		}

        if (Input.GetButtonDown("Submit")) {
            SceneManager.LoadScene("Play");
        }
	}

	int Mod(int i, int n) {
		int r = i % n;
		return r < 0 ? r + n : r;
	}
}
