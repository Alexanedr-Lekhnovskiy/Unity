using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    private LevelData _levelData;

    [SerializeField]
    private Button _easyButton;

    [SerializeField]
    private Button _themeButton;

    public void SetDifficult(int value)
    {
        _levelData.MaxPlayCards = value;
    }
    public void SetTheme(string name)
    {
        _levelData.ThemeName = name;
    }

    private void OnEnable()
    {
        _easyButton.onClick.Invoke();
        _themeButton.onClick.Invoke();
    }
}
