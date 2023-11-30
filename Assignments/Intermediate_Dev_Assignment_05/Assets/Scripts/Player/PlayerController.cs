using UnityEngine;

/// <summary>
/// This class is a singleton class.
/// This script should and only should be given a single "Player" object unless this game becomes multiplayer.
/// This class is intended for player to interact with other objects
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(BoxCollider2D))]


public sealed class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance => instance;

    #region references
    private PlayerAnimationController animationController;
    private PlayerMovementController movementController;

    private GameManager gameManager;
    private HungerSystem hungerSystem;
    private SpriteRenderer playerSprite;

    #endregion

    #region components


    #endregion
    public delegate void PlayerEventDelegate();
    private void Awake() //set static and components references
    {
        instance = this;
    }
    private void Start() //set references to other GameObject and their components
    {
        animationController = GetComponent<PlayerAnimationController>();
        movementController = GetComponent<PlayerMovementController>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();

    }
    private void Update()
    {
        
    }
    private void SetPlayerCollider()
    {

    }
    #region events


    #endregion
}
