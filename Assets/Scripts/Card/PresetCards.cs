using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PresetCards : MonoBehaviour
{
    private Sprite _backSprite;
    private List<Sprite> _allSprites;

    [SerializeField]
    private LevelData _levelData;

    private readonly ResourceLoader resourceLoader = new ResourceLoader();

    [SerializeField]
    private UnityEvent _onLoaded = new UnityEvent(); 

    public void GetSprites()
    {
        Theme theme = resourceLoader.GetTheme(_levelData.ThemeName);
        _backSprite = theme.BackSprite;
        _allSprites = theme.AllSprites;
        _onLoaded.Invoke();
    }

    public Sprite GetBackSprite()
    {
        return _backSprite;
    }

    public List<Sprite> GetPlayCardsSprites()
    {
        List<Sprite> sprites = new List<Sprite>(_allSprites);
        while (_levelData.MaxPlayCards > sprites.Count)
        {
            sprites.RemoveAt(Random.Range(0, sprites.Count));
        }

        return sprites;
    }

    public int[] GetCardIndex()
    {
        int[] cardIndex = new int[_levelData.MaxPlayCards * 2];
        for (int i = 0; i < cardIndex.Length; i++)
        {
            cardIndex[i] = i / 2;
        }
        for (int i = 0; i < cardIndex.Length; i++)
        {
            int temp = cardIndex[i];
            int rnd = Random.Range(0, cardIndex.Length);
            cardIndex[i] = cardIndex[rnd];
            cardIndex[rnd] = temp;
        }

        return cardIndex;
    }

}
