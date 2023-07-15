using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public Color[] colors;

    public void Start() {
        StartCoroutine(ChangeColor());

    }

    IEnumerator ChangeColor() {

        while (true) {
            int randomColor = Random.Range(0, 5);

            Camera.main.backgroundColor = colors[randomColor];

            yield return new WaitForSeconds(10f);
        }
    }


}
