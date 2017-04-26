using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class ScoreSceneController : MonoBehaviour {

    [SerializeField]
    GameObject score = null;

    [SerializeField]
    GameObject image = null;

    [SerializeField]
    CharacterManager characterManager;

    [SerializeField]
    AudioClip enterAudio;

    [SerializeField]
    AudioClip inputAudio;

    [SerializeField]
    float minimumWait = 3.0f;

    float waitExpiry;

    AudioSource audioSource;

    [SerializeField]
    Text countdownText;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        score.GetComponent<Text>().text = "You scored " + Words.score.ToString() + " points!";
        image.GetComponent<Image>().sprite = characterManager.characters[Words.selected].sprite;
        waitExpiry = Time.realtimeSinceStartup + minimumWait;
        audioSource.PlayOneShot(enterAudio);
    }

    void Update() {
        if (Time.realtimeSinceStartup > waitExpiry) {
            countdownText.enabled = false;
            if (Input.GetButtonDown("Submit")) {
                Words.input = "";
                Words.score = 0;
                audioSource.PlayOneShot(inputAudio);
                SceneManager.LoadScene("Select");
            }
        } else {
            countdownText.text = (waitExpiry - Time.realtimeSinceStartup).ToString("F1");
        }
    }
}
