using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bennet;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;

public class DrawManager : MonoBehaviour
{
    private static DrawManager instance;
    public static DrawManager Instance => instance;

    [SerializeField] private ColorPicker colorPicler;

    private RectTransform rectTransform;
    private HistoryManager historyManager;
    private bool drawing = false;
    private Stroke stroke;
    private void Awake()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
        historyManager = new HistoryManager();
    }
    private void Start()
    {
        SetCanvasSize(_canvasSize);
        ZoomInCanvas(1);
        SetCanvasBackground(backgroundType);
        var backgroundLayer = CreateNewDrawLayer("Background");
        currentDrawingLayer = backgroundLayer;
        /*
        stroke = CreateNewStroke();
        */
    }
    private void Update()
    {
        //mouse whell zoom feature
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            ZoomInCanvas(MOUSE_WHELL_ZOOM_FACTOR);
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            ZoomOutCanvas(MOUSE_WHELL_ZOOM_FACTOR);
        //if clicked on the canvas, then draw

        /*
        if (Input.GetMouseButtonDown(0))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out Vector2 localPoint);
            if (rectTransform.rect.Contains(localPoint))
            {
                stroke.startDrawing = true;
                stroke.color = strokeColor;
                stroke.width = strokeWidth;
                drawing = true;
            }

        }
        if (drawing && Input.GetMouseButtonUp(0))
        {
            stroke.EndStroke();
        }
        if (!drawing && Input.GetKeyDown(KeyCode.Z))// && (Input.GetKey(KeyCode.LeftControl)))
            historyManager.UndoStep();
        if (!drawing && Input.GetKeyDown(KeyCode.Y))
            historyManager.RedoStep();
        */
    }
    #region canvas related
    [SerializeField] private Vector2Int _canvasSize;
    public Vector2Int CanvasSize //use setter to prevent bug since canvas Size should not be negative
    {
        get => _canvasSize;
        set
        {
            try
            {
                if (value.x <= 0 || value.y <= 0)
                    throw new ArithmeticException($"Canvas size cannot be smaller than 0, the input value is {value}");
                _canvasSize = value;
            }
            catch (ArithmeticException ex)
            {
                Debug.LogError(ex.Message);
                return;
            }
        }
    }
    private Vector2Int _canvasDisplayedSize;
    private Vector2Int CanvasDisplayedSize
    {
        get => _canvasDisplayedSize;
        set
        {
            try
            {
                if (value.x <= 0 || value.y <= 0)
                    throw new ArithmeticException($"Canvas displayed size on screen cannot be smaller than 0, the input value is {value}");
                _canvasDisplayedSize = value;
            }
            catch (ArithmeticException ex)
            {
                Debug.LogError(ex.Message);
                return;
            }
            _canvasDisplayedSize = value;

        }
    }
    public enum BackgroundType { WhiteBackground, BlackBackground, TransparentDarkBackground, TransparentLightBackground }
    [SerializeField] private BackgroundType _backgroundType;
    public BackgroundType backgroundType => _backgroundType;
    private readonly float MOUSE_WHELL_ZOOM_FACTOR = Mathf.Sqrt(Mathf.Sqrt(2));
    private float _zoomRate;
    /// <summary> Please treat this as a percentage, i.e. a value of 100 means that there is no scaling </summary>
    public float ZoomRate
    {
        get => _zoomRate;
        private set
        {
            try
            {
                if (value <= 1)
                {
                    throw new ArithmeticException($"Zoom rate cannot be smaller than 0%. Input value is {value}");
                }
                else if (value > 3200)
                {
                    _zoomRate = 3200;
                    throw new ArithmeticException($"Zoom rate cannot be greater than 3200%. Input value is {value}");
                }
            }
            catch (ArithmeticException ex)
            {
                Debug.LogError(ex.Message);
                return;
            }
            _zoomRate = value;
        }
    }
    private void SetCanvasSize(Vector2Int size)
    {
        var rectTransform = GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);

        var material = GetComponent<RawImage>().material;
        material.mainTextureScale = new Vector2 (size.x / 32, size.y / 32);

        ZoomRate = 100;
    }
    private void SetCanvasDisplayedSize(Vector2Int size)
    {
        var rectTransform = GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);
    }
    private void SetCanvasBackground(BackgroundType backgroundType)
    {
        this._backgroundType = backgroundType;
        RawImage image = GetComponent<RawImage>();
        Texture2D texture = Resources.Load<Texture2D>("Sprites/CanvasBackgrounds/" + backgroundType.ToString());
        image.texture = texture;
    }
    private void ZoomInCanvas(float factor)
    {
        ZoomRate *= factor;
        int tempX = (int)MathF.Floor(CanvasSize.x * ZoomRate / 100);
        int tempY = (int)MathF.Floor(CanvasSize.y * ZoomRate / 100);
        CanvasDisplayedSize = new Vector2Int(tempX, tempY);
        SetCanvasDisplayedSize(CanvasDisplayedSize);
        Debug.Log($"Displayed size is: {CanvasDisplayedSize}");
        Debug.Log($"Zoom rate is: {ZoomRate}");
    }
    private void ZoomOutCanvas(float factor)
    {
        ZoomRate /= factor;
        int tempX = (int)MathF.Floor(CanvasSize.x * ZoomRate / 100);
        int tempY = (int)MathF.Floor(CanvasSize.y * ZoomRate / 100);
        CanvasDisplayedSize = new Vector2Int(tempX,tempY);
        SetCanvasDisplayedSize(CanvasDisplayedSize);
        Debug.Log($"Displayed size is: {CanvasDisplayedSize}");
        Debug.Log($"Zoom rate is: {ZoomRate}");
    }

    #endregion

    #region layers related

    DrawLayer currentDrawingLayer;
    private List<DrawLayer> drawLayers = new List<DrawLayer>();
    /// <summary>Yes, you can directly give it a name</summary>
    public DrawLayer CreateNewDrawLayer(string name)
    {
        var obj = Instantiate(Resources.Load<GameObject>("Prefabs/Drwaing Layer"), transform);
        var newLayer = obj.GetComponent<DrawLayer>();
        newLayer.LayerName = name;
        drawLayers.Add(newLayer);
        return newLayer;
    }
    /// <summary> By default, a new layer is called "Layer ..." </summary>
    public void CreateNewDrwaingLayer()
    {
        int biggestLayerNumber = 0;
        foreach (var layer in drawLayers)
        {
            if (layer.LayerName.StartsWith("Layer "))
            {
                if (int.TryParse(layer.LayerName.Remove(0,6), out int number))
                    if (number > biggestLayerNumber)
                        biggestLayerNumber = number;
            }
        }
        CreateNewDrawLayer($"Layer {biggestLayerNumber}");
    }

    #endregion

    #region strokes related
    /// <summary>When you click the canvas, create a new stroke</summary>
    public void AssignNewStepToCurrentLayer(GameObject newStep) //TODO
    {
        newStep.transform.SetParent(currentDrawingLayer.transform);
        currentDrawingLayer.AddNewStep(newStep);
    }
    #endregion

   #region Histroy Record
   public void CreateNewHistoryRecord(ActionType actionType)
    {
        historyManager.AddNewRecord(new HistoryRecord(currentDrawingLayer, actionType,$"New {actionType.ToString()}"));
    }
    public enum ActionType
    {
        Stroke,
    }

    #endregion
}

class HistoryManager
{
    private List<HistoryRecord> records;
    public int maxRecordCount = 10;
    private int currentRecordIndex;
    public HistoryManager()
    {
        records = new List<HistoryRecord>();
    }
    /// <summary>If the limit on the number of history records is reached, First In, First Out. If add a new history, when you cannot cancel withdraw anymore.</summary>
    public void AddNewRecord(HistoryRecord newHistory)
    {
        //first in first out
        if (records.Count >= maxRecordCount)
            records.RemoveAt(0);

        //if add a new step and there's withdraws, remove them all
        if (currentRecordIndex != records.Count - 1)
            CleraUndoneRecords();
        records.Add(newHistory);
        currentRecordIndex = records.Count - 1; //point to the last index
    }
    public void UndoStep()
    {
        if (currentRecordIndex < 0)
        {
            Debug.Log("No further history record undoable");
            return;
        }
        records[currentRecordIndex].layer.UndoStep();
        currentRecordIndex--;
    }
    public void RedoStep()
    {
        if (currentRecordIndex + 1 > records.Count - 1)
        {
            Debug.Log("No further history record redoable");
            return;
        }
        currentRecordIndex++;
        records[currentRecordIndex].layer.RedoStep();
        
    }
    private void CleraUndoneRecords()
    {
        //I suppose this won't cause out of index bug
        for (int i = records.Count - 1; i > currentRecordIndex; i--)
        {
            records[i].layer.ClearUndoneSteps();
            records.RemoveAt(i);
        }
    }

}

struct HistoryRecord
{
    public DrawLayer layer;
    public string note;
    public DrawManager.ActionType actionType;

    public HistoryRecord(DrawLayer layer, DrawManager.ActionType actionType, string note)
    {
        this.layer = layer;
        this.actionType = actionType;
        this.note = note;
    }
}
