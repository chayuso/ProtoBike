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
        if (gState.reset)
        {
            StopAllCoroutines();
            startCount = true;
            countFinished = false;
            text.text = "3";
            gState.globalClock = gState.totalTime;
        }
		if (gState.StartGame && startCount) {
			startCount = false;
			text.enabled = true;
			StartCoroutine(Count(3));
		}

		if (gState.globalClock < gState.totalTime-1)
			text.enabled = false;
	}
    IEnumerator Count(int i)
    {
        int num = i;
        if (num == 3)
        {
            text.text = "3";
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            while (text.color.a > 0.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 1.0f));
                yield return null;
            }
            num = 2;
        }
        if (num==2)
        {
            text.text = "2";
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            while (text.color.a > 0.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 1.0f));
                yield return null;
            }
            num = 1;
        }
        if (num == 1)
        {
            text.text = "1";
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            while (text.color.a > 0.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 1.0f));
                yield return null;
            }
            num = 0;
        }
        if (num == 0)
        {
            text.text = "GO!";
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            countFinished = true;
        }
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
