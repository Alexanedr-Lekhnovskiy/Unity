using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreUI : MonoBehaviour
{
    private Text _text = null;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void UpdateText(int value)
    {
        _text.text = value.ToString();
    }
}
