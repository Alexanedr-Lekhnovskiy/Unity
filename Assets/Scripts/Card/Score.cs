using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private const int Add = 60;
    private const int Remove = -20;
    private int _value;

    [SerializeField]
    private IntEvent _onUpdated = new IntEvent();

    public void ResetScore()
    {
        _value = 0;
        _onUpdated.Invoke(_value);
    }

    public void AddRemove(bool addRemove)
    {
        _value += addRemove == true ? Add : Remove;
        if (_value < 0)
        {
            _value = 0;
        }
        _onUpdated.Invoke(_value);
    }
}

[System.Serializable]
public class IntEvent : UnityEvent<int> { }