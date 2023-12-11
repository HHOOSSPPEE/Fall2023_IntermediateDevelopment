using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLayer : MonoBehaviour
{
    private string _layerName;
    public string LayerName
    { 
        get => _layerName;
        set
        {
            _layerName = value;
            gameObject.name = value;
        }
    }
    public Vector2Int size;
    private List<GameObject> steps = new List<GameObject>();
    private List<GameObject> undoneSteps = new List<GameObject>();
    

    public void AddNewStep(GameObject newStep)
    {
        steps.Add(newStep);
        newStep.name = $"{LayerName}'s Step {steps.Count}";
    }
    public void UndoStep()
    {
        var step = steps[steps.Count - 1];
        step.SetActive(false);
        undoneSteps.Add(steps[steps.Count - 1]);
        steps.RemoveAt(steps.Count - 1);
    }
    public void RedoStep()
    {
        var step = undoneSteps[undoneSteps.Count - 1];
        step.SetActive(true);
        steps.Add(undoneSteps[undoneSteps.Count - 1]);
        undoneSteps.RemoveAt(undoneSteps.Count - 1);
    }
    public void ClearUndoneSteps()
    {
        undoneSteps.Clear();
    }
}
