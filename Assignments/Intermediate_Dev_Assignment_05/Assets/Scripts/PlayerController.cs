using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerController : MonoBehaviour
{
    #region movement
    [Header("Movement State")]
    [SerializeField] private bool allowMovementInput = true;
    [SerializeField] private bool isFlying = false;
    [SerializeField] private bool isDashing = false;
    [SerializeField] private bool grounded = false;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float flightSpeed;

    [Header("Dash")]
    [SerializeField] private bool allowDash = true;
    [SerializeField] private bool isDashRecovered = true;
    [SerializeField] private float dashSpeed = 2.0f;
    [SerializeField] private float dashAirSpeed = 2.0f;
    [SerializeField] private float dashDurationSecond = 0.5f;
    [SerializeField] private float dashRecoverySecond = 0.5f;
    [Tooltip("Bat Effect Prefab")][SerializeField] private GameObject dashEffectBatPrefab;
    [Tooltip("Trail Renderer Prefab")][SerializeField] private GameObject dashEffectTrailPrefab;
    [SerializeField] private float dashEffectBatsCount = 10;
    private bool hasDashInput;

    [Header("Jump")]
    /// <summary>the force will be applied strait up </summary>
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private bool allowJump = true;
    private bool hasJumpInput;
    private int currentJumps = 0;

    #endregion

    private float horizontalInput;
    private float verticalInput;
    private enum FacingDirection { Left, Right }
    private FacingDirection facingDirection = FacingDirection.Right;

    #region components
    public static PlayerController instance;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _vampireCollider;
    private CircleCollider2D _batCollider;
    private Animator _animator;
    #endregion

    private const float INPUT_THRESHOLD = 0.01f;
    private float initialGravityScale;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _vampireCollider = GetComponent<BoxCollider2D>();
        _batCollider = GetComponent<CircleCollider2D>();
        _animator = GetComponent<Animator>();
        initialGravityScale = _rigidbody2D.gravityScale;

        #region just for test, not going to affect game experience
        /*
        if (isFlying)
            SetFlyingStart();
        else
            SetFlyingEnd();
        */
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region casting
        if (Input.GetKeyDown(_startCastingKey))
        {
            if (_isCasting)
            {
                EndCasting();
            }
            else
                StartCasting();
        }
        if (_isCasting)
        {
            CheckForKeyPress();
            var hungerSystem = HungerSystem.instance;
            hungerSystem.setHungerValue(hungerSystem.getHungerValue() - castingHungerValueConsumptionRate * Time.deltaTime);
        }
        #endregion

        #region movement
        if (allowMovementInput && !isDashing)
        { 
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            hasJumpInput = GetInputAxisRawActive("Jump");
            hasDashInput = GetInputAxisRawActive("Dash");

            _rigidbody2D.velocity = new Vector2((isFlying ? flightSpeed : moveSpeed) * horizontalInput, 
                                                (isFlying ? verticalInput * flightSpeed : _rigidbody2D.velocity.y));
            if (GetInputAxisRawActive("Horizontal")) // Facing direction
                facingDirection = horizontalInput > 0 ? FacingDirection.Right : FacingDirection.Left;

            if (hasDashInput && allowDash && isDashRecovered) // Dash
                SetDashStart();

            if (hasJumpInput && currentJumps < maxJumps &&! isFlying)
                SetJumpingStart();




            
        }
        _spriteRenderer.flipX = facingDirection == FacingDirection.Left;
        #endregion
    }
    #region jumping
    private void SetJumpingStart()
    {
        _rigidbody2D.AddForce(new Vector2(0, jumpForce));
        currentJumps++;

    }
    #endregion

    #region flight
    private void SetFlyingStart()
    {
        isFlying = true;
        _rigidbody2D.gravityScale = 0;
        _vampireCollider.enabled = false;
        _batCollider.enabled = true;
        CreateDashEffectObjects();
    }
    private void SetFlyingEnd()
    {
        isFlying = false;
        _rigidbody2D.gravityScale = initialGravityScale;
        _vampireCollider.enabled = true;
        _batCollider.enabled = false;
    }
    #endregion

    #region dash
    private void SetDashStart()
    {
        isDashing = true;
        allowDash = false;
        isDashRecovered = false;
        CreateDashEffectObjects();
        _rigidbody2D.gravityScale = 0;

        if (isFlying && (GetInputAxisRawActive("Horizontal") || GetInputAxisRawActive("Vertical"))) //there's input when dash in the air
            _rigidbody2D.velocity = new Vector2(horizontalInput * dashAirSpeed, verticalInput * dashAirSpeed);
        else if (isFlying)
            _rigidbody2D.velocity = new Vector2((facingDirection == FacingDirection.Right ? 1 : -1) * dashAirSpeed, 0); // if there's no input then just dash "forward"
        else
            _rigidbody2D.velocity = new Vector2(((facingDirection == FacingDirection.Right)? 1: -1) * 2 * dashSpeed, 0); 
        StartCoroutine("StopDashingAfterSeconds");
    }
    private void InterruptDash()
    {
        isDashing = false;
        allowDash = false;
        isDashRecovered = false;
        StopCoroutine("StopDashingAfterSeconds");
        StopCoroutine("EnableDashingAfterSeconds");
    }
    /// <summary>Basically some random bats</summary>
    private void CreateDashEffectObjects()
    {
        Instantiate(dashEffectTrailPrefab).transform.SetParent(transform, false);
        for (int i = 0; i < dashEffectBatsCount; i++) //bats
            Instantiate(dashEffectBatPrefab).transform.position = transform.position;
    }
    public bool GetIsDashing() => isDashing;
    #endregion

    #region useful tools
    private bool GetInputAxisRawActive(string axisName)
    {
        float input = Input.GetAxisRaw(axisName);
        return Mathf.Abs(input) > INPUT_THRESHOLD;
    }
    private bool GetInputAxisActive(string axisName)
    {
        float input = Input.GetAxis(axisName);
        return Mathf.Abs(input) > INPUT_THRESHOLD;
    }
    #endregion

    #region casting
    [SerializeField] private KeyCode _startCastingKey = KeyCode.E;
    [SerializeField] private List<KeyCode> _spellKeys = new List<KeyCode>();
    private List<KeyCode> _castedKeys = new List<KeyCode>();
    [SerializeField] private float castingHungerValueConsumptionRate = 5.0f;
    private bool _isCasting = false;

    [SerializeField] private KeyCode _suckingKey = KeyCode.F;
    [SerializeField] private SuckingTrigger suckingTrigger;
    [SerializeField] private KeyCode [] batSpellKeys = new KeyCode[0];
    [SerializeField] private KeyCode[] fireballSpellKeys = new KeyCode[0];

    private void StartCasting()
    {
        _isCasting = true;
        _animator.SetTrigger("startCasting");
        allowMovementInput = false;
    }
    private void TrySucking()
    {
        var obj = Instantiate(suckingTrigger);
        obj.transform.SetParent(transform);
        var trigger = obj.GetComponent<SuckingTrigger>();
        if (trigger.detected)
            _animator.SetTrigger("suckBloodSucces");
        else
            _animator.SetTrigger("suckBloodFailed");
    }
    private void EndCasting()
    {
        _isCasting = false;
        allowMovementInput = true;
        CheckSpellCasting();

        _castedKeys.Clear();
    }
    private void CheckForKeyPress()
    {
        foreach (KeyCode spellKey in  _spellKeys)
        {
            if (Input.GetKeyDown(spellKey))
                _castedKeys.Add(spellKey);
        }
    }
    private void CheckSpellCasting()
    {
        if (_spellKeys.Count == batSpellKeys.Length)
            for (int i = 0; i < batSpellKeys.Length && i < _spellKeys.Count; i++)
            {
                if (_spellKeys[i] != batSpellKeys[i])
                    break;
                _animator.SetTrigger("batModeCasted");
                SetFlyingStart();
                return;
            }
            if (_spellKeys.Equals(fireballSpellKeys))
            {
                _animator.SetTrigger("fireballCasted");
                return;
            }
        _animator.SetTrigger("endCasting");
    }
    #endregion

    #region coroutines
    IEnumerator StopDashingAfterSeconds()
    {
        yield return new WaitForSeconds(dashDurationSecond);
        isDashing = false;
        if (!isFlying)
            _rigidbody2D.gravityScale = initialGravityScale;
        StartCoroutine("EnableDashingAfterSeconds");
    }
    IEnumerator EnableDashingAfterSeconds()
    {
        yield return new WaitForSeconds(dashRecoverySecond);
        isDashRecovered = true;
        if (isFlying) allowDash = true;
    }
    #endregion
}
