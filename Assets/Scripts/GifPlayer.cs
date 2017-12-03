using UnityEngine;
using System.Collections;

public class GifPlayer : MonoBehaviour {
    public Texture[] frames = new Texture[] { };
    public float frameDelay = 1;

    private int index = 0;

    void Start()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(frameDelay);
            if (index >= frames.Length)
            {
                index = 0;
            }
            gameObject.GetComponent<Renderer>().material.mainTexture = frames[index];
            ++index;
        }
    }
}
