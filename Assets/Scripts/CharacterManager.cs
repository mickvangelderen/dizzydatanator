using UnityEngine;

public class CharacterManager : MonoBehaviour {

	[System.Serializable]
	public class Character {
		public Sprite sprite;
		public string name;
		public string description;
	}

	[SerializeField]
	public Character[] characters = null;
}
