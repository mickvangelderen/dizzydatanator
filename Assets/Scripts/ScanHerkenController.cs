using UnityEngine;
using UnityEngine.UI;

public class ScanHerkenController : MonoBehaviour {
	[SerializeField]
	Vector3 initialScale = new Vector3(4.0f, 4.0f, 4.0f);

	[SerializeField]
	Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f);

	[SerializeField]
	Color initialColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

	[SerializeField]
	Color targetColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);

	GameObject canvasObject;

	float startTime;
	
	// Use this for initialization
	void Start () {
		canvasObject = GameObject.Find("Canvas");
		transform.SetParent(canvasObject.transform);

		RectTransform canvasRect = canvasObject.GetComponent<RectTransform>();

		RectTransform thisRect = GetComponent<RectTransform>();

		thisRect.anchoredPosition = new Vector2(
			Random.Range(canvasRect.rect.xMin, canvasRect.rect.xMax),
			Random.Range(canvasRect.rect.yMin, canvasRect.rect.yMax)
		);

		thisRect.localRotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 1.0f));

		startTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		float progress = (Time.realtimeSinceStartup - startTime)/1.0f;
		transform.localScale = Vector3.Lerp(initialScale, targetScale, progress);
		GetComponent<Text>().color = Color.Lerp(initialColor, targetColor, progress);
		if (progress > 1.0f) {
			Destroy(gameObject);
		}
	}
}
