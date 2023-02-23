using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

public class test : MonoBehaviour
{
    private RectTransform _text;
    void Start()
    {
        _text = GetComponent<RectTransform>();
        StartCoroutine(Sda());
    }
    

    private IEnumerator Sda()
    {
        yield return new WaitForSeconds(0.01f);
        _text.localScale = new Vector3(Time.deltaTime * 100, Time.deltaTime * 100);//Random.Range(0f,1f), Random.Range(0f,1f)
        StartCoroutine(Sda());
    }
}
