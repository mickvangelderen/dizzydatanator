using UnityEngine;
using UnityEngine.UI;

class ScoreController : MonoBehaviour {

    Text textController = null;

    void Start() {
        textController = GetComponent<Text>();
    }

    void Update() {
        textController.text = Words.score.ToString();
    }
}