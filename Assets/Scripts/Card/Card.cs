using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Card : MonoBehaviour, IPointerClickHandler
{
    private SpriteRenderer _spriteRenderer;
    private Sprite _backSprite;
    private Sprite _frontSprite;
    private Animation _animation;
    private bool _isBackSide = true;
    private BoxCollider2D _boxCollider2D;
    public int Index { get; private set; }

    private CardCollector _cardCollector;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animation = GetComponent<Animation>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_cardCollector.TwoCardsClosed())
        {
            _boxCollider2D.enabled = false;
            CardAnimation();
            _cardCollector.OpenCard(this);
        }
    }

    private void EnableCollider()
    {
        _boxCollider2D.enabled =true;
    }

    private void ChangeSpriteCard()
    {
        _spriteRenderer.sprite = _isBackSide == true ? _backSprite : _frontSprite;
    }

    public void CardAnimation()
    {
        _isBackSide = !_isBackSide;
        _animation.Play(_isBackSide == true ? "ToBack" : "ToFront");
    }

    public void CardsSettings(Sprite back, Sprite front, int index)
    {
        _spriteRenderer.sprite = _backSprite = back;
        _frontSprite = front;
        Index = index;
    }    

    public void SetCardCollector(CardCollector cardCollector)
    {
        _cardCollector = cardCollector;
    }
}
