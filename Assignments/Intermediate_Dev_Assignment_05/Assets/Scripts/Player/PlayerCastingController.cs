using BennetTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCastingController : MonoBehaviour
{
    private static PlayerCastingController instance;
    public static PlayerCastingController Instance => instance;

    private bool allowCasting = true;
    private bool isCasting;
    public KeyCode startCastingKey;
    [SerializeField] private float castingHungerConsumption = 20;
    [SerializeField] private List<KeyCode> spellKeys = new List<KeyCode> { KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow};
    [SerializeField] private List<KeyCode> castedKeys;
    [SerializeField] private int maxCastCount = 6;

    [SerializeField] private KeyCode[] spellsToTransformation;
    [SerializeField] private KeyCode[] spellsToBloodSucking;
    [SerializeField] private BloodSuckingDetector bloodSuckingDetector;
    private bool sucking = false;
    [SerializeField] private float bloodSuckingSeconds = 1f;
    private enum Spell { Transformation, BloodSucking }

    private void Awake()
    {
        instance = this;
        castedKeys = new List<KeyCode>();
    }
    private void Start()
    {
        HungerSystem.Instance.OnHungerValueCritical += HandleCriticalHungerValue;
        HungerSystem.Instance.OnHungerValueSafe += HandleSafeHungerValue;
        bloodSuckingDetector.OnEnemyDetected += HandleOnSuckingBloodEnemyDetected;
    }
    private void HandleOnSuckingBloodEnemyDetected(GameObject enemyObject)
    {
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        if (enemy != null)
        {

            enemy.SetTrigger(Enemy.AnimationTrigger.beingSucked);
            PlayerAnimationController.Instance.SetTrigger(PlayerAnimationController.AnimationTrigger.endBloodSuckingLoop);
            StartCoroutine(EndBloodSucking(enemy, bloodSuckingSeconds));
        }
    }
    IEnumerator EndBloodSucking(Enemy enemy, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        enemy.SetTrigger(Enemy.AnimationTrigger.beingSuckedLoopEnd);
        PlayerAnimationController.Instance.SetTrigger(PlayerAnimationController.AnimationTrigger.endBloodSuckingLoop);
        PlayerMovementController.Instance.EnableMovement();

    }
    /// <summary> When the hunger value is critical, you cannot cast any spell, and current spell will be interrupted </summary>
    private void HandleCriticalHungerValue()
    {
        EndCasting();
        DisableCasting();
    }
    /// <summary> When the hunger value is safe, you can cast spells again </summary>
    private void HandleSafeHungerValue()
    {
        EnableCasting();
    }

    private void Update()
    {
        if (allowCasting)
        {
            if (Input.GetKeyDown(startCastingKey))
            {
                StartCasting();
            }
            if (Input.GetKeyUp(startCastingKey) && castedKeys.Count > 0)
            {
                EndCasting();
            }
            if (isCasting)
            {
                GetSpellKeysInput();
            }
        }
    }
    public void StartCasting()
    {
        isCasting = true;
        PlayerAnimationController.Instance.SetTrigger(PlayerAnimationController.AnimationTrigger.startCasting);
        PlayerMovementController.Instance.DisableMovement();
        Debug.Log("start casting");
    }
    public void EndCasting()
    {
        isCasting = false;
        var spell = CheckCastedSpells();
        Debug.Log(spell.ToString());

        if (spell == Spell.Transformation)
            StartTransformation();
        else if (spell == Spell.BloodSucking)
            StartBloodSucking();

        castedKeys.Clear();
        PlayerAnimationController.Instance.SetTrigger(PlayerAnimationController.AnimationTrigger.endCastingLoop);
    }
    private void EnableCasting() => allowCasting = true;
    private void DisableCasting() => allowCasting = false;
    private void StartTransformation()
    {
        PlayerAnimationController.Instance.SetTrigger(PlayerAnimationController.AnimationTrigger.startTransformation);
        PlayerMovementController.Instance.StartFlying();
        PlayerMovementController.Instance.EnableMovement();
        StartCoroutine(EndTransformAfterSeconds(5));
    }
    private IEnumerator EndTransformAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);

        PlayerAnimationController.Instance.SetTrigger(PlayerAnimationController.AnimationTrigger.backToIdle);
        PlayerMovementController.Instance.StopFlying();
    }
    private void StartBloodSucking()
    {
        PlayerAnimationController.Instance.SetTrigger(PlayerAnimationController.AnimationTrigger.enterBloodSuckingLoop);
    }

    private Spell? CheckCastedSpells()
    {
        //check for to bat form
        
        if (spellsToBloodSucking.ToList().ValueEquals(castedKeys))
            return Spell.BloodSucking;

        if (spellsToTransformation.ToList().ValueEquals(castedKeys))
            return Spell.Transformation;

        return null;
    }
    private void GetSpellKeysInput()
    {
        foreach (KeyCode key in spellKeys)
        {
            if (Input.GetKeyDown(key)) 
            {
                castedKeys.Add(key);
                HungerSystem.Instance.SetHungerValue(HungerSystem.Instance.GetMaxHungerValue() - castingHungerConsumption);
            }
            if (castedKeys.Count >= maxCastCount)
            {
                EndCasting();
            }
        }
    }

}
