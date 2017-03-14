using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
	public GameObject GameState;
	public bool startCount = true;
	public bool countFinished = false;

	private GameState gState;
	private Text text;
	// Use this for initialization
	void Start () {
		gState = GameState.GetComponent<GameState> ();
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gState.StartGame && startCount) {
			startCount = false;
			text.enabled = true;
			StartCoroutine(FadeTextToZeroAlpha(text));
		}

		if (gState.globalClock < 99)
			text.enabled = false;
	}

	public IEnumerator FadeTextToZeroAlpha(Text i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / 1.0f));
			yield return null;
		}

		i.text = "2";

		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / 1.0f));
			yield return null;
		}

		i.text = "1";

		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / 1.0f));
			yield return null;
		}

		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		i.text = "GO!";
		countFinished = true;
	}
}
