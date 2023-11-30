using BennetTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// for now just assume there's only one
/// </summary>
public class Enemy : MonoBehaviour
{
    public string enemyName { get; set; }

    private float _maxHP;
    private float _minHP;
    private float _HP;
    private BoxCollider2D _boxCollider;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    public float HP
    {
        get => _HP;
        set => _HP = Mathf.Clamp(value, _minHP, _maxHP);
    }
    public float MaxHP
    {
        get => _maxHP;
        set
        {
            if (value < _minHP)
            {
                Debug.Log("Invalid input. MaxHP should never be smaller than minHP.");
                return;
            }
            _maxHP = value;
        }
    }
    public float MinHP
    {
        get => _minHP;
        set
        {
            if (value > _maxHP)
            {
                Debug.Log("Invalid input. MinHp should never be greater than maxHP.");
                return;
            }
            _minHP = value;
        }
    }

    private bool _isPaused;

    private void Awake()
    {
        SetTag2Enemy();
        _boxCollider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        _boxCollider.AdjustColliderToFitSprite(_spriteRenderer);
    }


    private void SetTag2Enemy() => gameObject.tag = "Enemy";


    public enum AnimationTrigger { beingSucked, beingSuckedLoopEnd, recovered }
    public void SetTrigger(AnimationTrigger trigger) => _animator.SetTrigger(trigger.ToString());

}