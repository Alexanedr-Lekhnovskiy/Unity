using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardSpawner : MonoBehaviour
{
    [SerializeField]
    private Grid _grid;

    [SerializeField]
    private PresetCards _presetCards;

    [SerializeField]
    private Card _cardPrefab;

    [SerializeField]
    private UnityEvent _startCollect = new UnityEvent();

    public void Spawn()
    {
        Transform localTransform = GetComponent<Transform>();
        Card card;
        Sprite backSprite = _presetCards.GetBackSprite();
        List<Sprite> playCardsSprites = _presetCards.GetPlayCardsSprites();

            int[] playCardsIndex = _presetCards.GetCardIndex();
            float positionX = _grid.GetPositionX();
            float positionY = _grid.PositionY;
            int count = _grid.GetColumsCount();

            for (int j = 0; j < playCardsIndex.Length; j++)
            {
                card = Instantiate(_cardPrefab) as Card;
                card.transform.position = new Vector3(positionX, positionY + localTransform.position.y);
                card.transform.parent = localTransform;
                card.CardsSettings(backSprite, playCardsSprites[playCardsIndex[j]], playCardsIndex[j]);
                positionX += _grid.OffestX;
                count --;
                if (count < 1)
                {
                    count = _grid.GetColumsCount();
                    positionY -= _grid.OffsetY;
                    positionX = _grid.GetPositionX();
                }
            }
        _startCollect.Invoke();
    }
}
