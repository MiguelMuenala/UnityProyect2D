using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    private float point;
    //private TextMeshProUGUI textMesh;
    Text textMesh;

    /*private void Strart()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }*/


    // Update is called once per frame
    private void Update()
    {
        point += Time.deltaTime;
        textMesh.text = point.ToString();

    }

    public void AddPoint(float n)
    {
        point += n;
    }
}
