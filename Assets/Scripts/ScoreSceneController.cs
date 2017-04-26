using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSceneController : MonoBehaviour {

    [SerializeField]
    GameObject score = null;

    [SerializeField]
    GameObject image = null;

    void Start() {
        score.GetComponent<Text>().text = "You scored " + Words.score.ToString() + " points!";
        image.GetComponent<Image>().sprite = Words.sprites[Words.selected];
    }

    void Update() {
        if (Input.GetButtonDown("Submit")) {
            Words.input = "";
            Words.score = 0;
            SceneManager.LoadScene("Select");
        }
    }
}
