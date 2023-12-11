using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Bennet;

public class ColorPicker : MonoBehaviour
{
    public float currentHue, currentSat, currentVal,currentAlpha;

    [SerializeField] private Slider hueSlider;
    [SerializeField] private Slider alphaSlider;
    [SerializeField] private GameObject colorPicker;
    private RectTransform colorPickerRectTransform;
    private float satValPanelWidth, satValPanelHeight;

    [SerializeField] private TMP_InputField hexInputField;
    [SerializeField] private MeshRenderer changeThisColor;
    private bool dragingPicker = false;
    public Color color;

    [SerializeField] private Image previewImage, satValImage, alphaImage;

    private static ColorPicker instance;
    public static ColorPicker Instance => instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        colorPickerRectTransform = colorPicker.GetComponent<RectTransform>();
        var satValPanel = satValImage.gameObject.GetComponent<RectTransform>();
        satValPanelWidth = satValPanel.rect.width;
        satValPanelHeight = satValPanel.rect.height;
        previewImage.material.SetTexture("_Background", Resources.Load<Texture2D>("Sprites/CanvasBackgrounds/" + DrawManager.Instance.backgroundType.ToString()));
        satValPanelHeight = satValImage.rectTransform.rect.height;
        satValPanelWidth = satValImage.rectTransform.rect.width;
    }
    private void Update()
    {
        //hue
        currentHue = hueSlider.value;
        //sat val
        if (!dragingPicker && Input.GetMouseButtonDown(0))
            dragingPicker = CheckIfPickerPressed();

        if (dragingPicker && Input.GetMouseButtonUp(0))
            dragingPicker = false;

        if (dragingPicker)
            DragColorPicker();

        satValImage.material.SetFloat("_Hue", currentHue);
        currentSat = colorPickerRectTransform.anchoredPosition.x / satValPanelWidth;
        currentVal = colorPickerRectTransform.anchoredPosition.y / satValPanelHeight;
        var rgbColor = Color.HSVToRGB(currentHue, currentSat, currentVal);
        //alpha
        currentAlpha = alphaSlider.value;
        alphaImage.material.SetColor("_Color", rgbColor);
        //preview
        previewImage.material.SetColor("_Color", rgbColor);
        previewImage.material.SetFloat("_Alpha", currentAlpha);
        //Code
        hexInputField.text = Tools.RGBtoHexString(color,false);
        //final color
        color = new Color(rgbColor.r, rgbColor.g, rgbColor.b, currentAlpha);
    }

    

    private void DragColorPicker()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(satValImage.rectTransform, Input.mousePosition, Camera.main, out Vector2 localPoint);
        localPoint = new Vector2(localPoint.x + satValPanelWidth / 2, localPoint.y + satValPanelWidth / 2);
        colorPickerRectTransform.anchoredPosition = new Vector2(Mathf.Clamp(localPoint.x, 0, satValPanelWidth), Mathf.Clamp(localPoint.y, 0, satValPanelHeight));
    }
    private bool CheckIfPickerPressed()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(satValImage.rectTransform, Input.mousePosition, Camera.main, out Vector2 localPoint);
        return satValImage.rectTransform.rect.Contains(localPoint);
    }
    public void OnDraggingPickerStart()
    {
        dragingPicker = true;
    }
}
