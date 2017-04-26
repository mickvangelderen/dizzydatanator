using UnityEngine;
using UnityEngine.UI;

public class PlaySceneController: MonoBehaviour {

	[SerializeField]
	GameObject image = null;

	[SerializeField]
	GameObject[] scanHerkenPrefabs = null;

	// Use this for initialization
	void Start () {
		image.GetComponent<Image>().sprite = Words.sprites[Words.selected];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
		Words.input += "a";
		}
		if (Input.GetKeyDown(KeyCode.B)) {
		Words.input += "b";
		}
		if (Input.GetKeyDown(KeyCode.C)) {
		Words.input += "c";
		}
		if (Input.GetKeyDown(KeyCode.D)) {
		Words.input += "d";
		}
		if (Input.GetKeyDown(KeyCode.E)) {
		Words.input += "e";
		}
		if (Input.GetKeyDown(KeyCode.F)) {
		Words.input += "f";
		}
		if (Input.GetKeyDown(KeyCode.G)) {
		Words.input += "g";
		}
		if (Input.GetKeyDown(KeyCode.H)) {
		Words.input += "h";
		}
		if (Input.GetKeyDown(KeyCode.I)) {
		Words.input += "i";
		}
		if (Input.GetKeyDown(KeyCode.J)) {
		Words.input += "j";
		}
		if (Input.GetKeyDown(KeyCode.K)) {
		Words.input += "k";
		}
		if (Input.GetKeyDown(KeyCode.L)) {
		Words.input += "l";
		}
		if (Input.GetKeyDown(KeyCode.M)) {
		Words.input += "m";
		}
		if (Input.GetKeyDown(KeyCode.N)) {
		Words.input += "n";
		}
		if (Input.GetKeyDown(KeyCode.O)) {
		Words.input += "o";
		}
		if (Input.GetKeyDown(KeyCode.P)) {
		Words.input += "p";
		}
		if (Input.GetKeyDown(KeyCode.Q)) {
		Words.input += "q";
		}
		if (Input.GetKeyDown(KeyCode.R)) {
		Words.input += "r";
		}
		if (Input.GetKeyDown(KeyCode.S)) {
		Words.input += "s";
		}
		if (Input.GetKeyDown(KeyCode.T)) {
		Words.input += "t";
		}
		if (Input.GetKeyDown(KeyCode.U)) {
		Words.input += "u";
		}
		if (Input.GetKeyDown(KeyCode.V)) {
		Words.input += "v";
		}
		if (Input.GetKeyDown(KeyCode.W)) {
		Words.input += "w";
		}
		if (Input.GetKeyDown(KeyCode.X)) {
		Words.input += "x";
		}
		if (Input.GetKeyDown(KeyCode.Y)) {
		Words.input += "y";
		}
		if (Input.GetKeyDown(KeyCode.Z)) {
		Words.input += "z";
		}
		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			Words.input += "0";
		}
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			Words.input += "1";
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			Words.input += "2";
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			Words.input += "3";
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			Words.input += "4";
		}
		if (Input.GetKeyDown(KeyCode.Alpha5)) {
			Words.input += "5";
		}
		if (Input.GetKeyDown(KeyCode.Alpha6)) {
			Words.input += "6";
		}
		if (Input.GetKeyDown(KeyCode.Alpha7)) {
			Words.input += "7";
		}
		if (Input.GetKeyDown(KeyCode.Alpha8)) {
			Words.input += "8";
		}
		if (Input.GetKeyDown(KeyCode.Alpha9)) {
			Words.input += "9";
		}
		if (Input.GetKeyDown(KeyCode.Period)) {
			Words.input += ".";
		}
		if (Input.GetKeyDown(KeyCode.Underscore)) {
			Words.input += "_";
		}
		if (Input.GetKeyDown(KeyCode.Return)) {
			string input = Words.input;
			foreach (FallingTextController c in FindObjectsOfType<FallingTextController>()) {
				c.CompleteInput(input);
			}
			Words.input = "";
			GameObject scanHerkenPrefab = scanHerkenPrefabs[Random.Range(0, scanHerkenPrefabs.Length)];
			Instantiate(scanHerkenPrefab, new Vector3(
				Random.Range(-4.0f, 4.0f),
				Random.Range(-4.0f, 4.0f),
				0
			), Quaternion.identity);
		}
	}

	int Mod(int i, int n) {
		int r = i % n;
		return r < 0 ? r + n : r;
	}
}
