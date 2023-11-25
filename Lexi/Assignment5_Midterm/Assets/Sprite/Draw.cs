using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public Color Pen_Colour;
    public Color Red_Pen_Colour;
    public Color Blue_Pen_Colour;
    public Color Yellow_Pen_Colour;
    public Color Orange_Pen_Colour;
    public Color Purple_Pen_Colour;
    public Color Green_Pen_Colour;
    public Color Copper_Pen_Colour;
    public Color Aqua_Pen_Colour;
    public Color Grey_Pen_Colour;
    public Color Corn_Pen_Colour;
    public Color Cerise_Pen_Colour;
    public Color Grass_Pen_Colour;
    public Color Amethyst_Pen_Colour;
    public Color White_Pen_Colour;
    public int Pen_Width = 2;

    public LayerMask Drawing_Layers;

    private Sprite drawable_sprite;
    private Texture2D drawable_texture;
    public int youryOffsetValue;
    public int yourxOffsetValue;

    private Vector2 previous_drag_position;
    private Color[] clean_colours_array;
    private Collider2D[] rayResult = new Collider2D[2];
    private Color32[] cur_colors;

    private bool no_drawing_on_current_drag = false;
    private bool mouse_was_previously_held_down = false;

    private BoxCollider2D myCollider;

    void Awake()
    {

        drawable_sprite = this.GetComponent<SpriteRenderer>().sprite;
        drawable_texture = drawable_sprite.texture;

        clean_colours_array = new Color[(int)drawable_sprite.rect.width * (int)drawable_sprite.rect.height];
        clean_colours_array = drawable_texture.GetPixels();

        myCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
        bool mouse_held_down = Input.GetMouseButton(0);

        if (mouse_held_down)
        {
            Vector3 mouse_world_position3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouse_world_position = new Vector2(mouse_world_position3D.x, mouse_world_position3D.y);

            mouse_world_position.y -= youryOffsetValue;
            mouse_world_position.x -= yourxOffsetValue;

            if (myCollider.OverlapPoint(mouse_world_position))
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.isPainting = true;
            }

            if (!no_drawing_on_current_drag)
            {
                
                Collider2D hit = Physics2D.OverlapPoint(mouse_world_position, Drawing_Layers.value);


                if (hit != null && hit.transform != null)
                {

                    PenBrush(mouse_world_position);

                }
                else
                {
                    previous_drag_position = Vector2.zero;
                    if (!mouse_was_previously_held_down)
                    {
                        no_drawing_on_current_drag = true;
                    }
                }

            }
        }
        
        else if (!mouse_held_down)
        {
            previous_drag_position = Vector2.zero;
            no_drawing_on_current_drag = false;
        }
        mouse_was_previously_held_down = mouse_held_down;
    }

    protected void OnDestroy()
    {
        ResetCanvas();
    }

    /// <summary>
    ///  ���û���
    /// </summary>
    public void ResetCanvas()
    {
        drawable_texture.SetPixels(clean_colours_array);
        drawable_texture.Apply();
    }

    /// <summary>
    ///  ��ˢ
    /// </summary>
    public void PenBrush(Vector2 world_point)
    {
        Vector2 pixel_pos = WorldToPixelCoordinates(world_point);

        cur_colors = drawable_texture.GetPixels32();

        if (previous_drag_position == Vector2.zero)
        {
            MarkPixelsToColour(pixel_pos, Pen_Width, Pen_Colour);
        }
        else
        {
            ColourBetween(previous_drag_position, pixel_pos, Pen_Width, Pen_Colour);
        }
        ApplyMarkedPixelChanges();

        previous_drag_position = pixel_pos;
    }

    private Vector2 WorldToPixelCoordinates(Vector2 world_position)
    {
        Vector3 local_pos = transform.InverseTransformPoint(world_position);

        float pixelWidth = drawable_sprite.rect.width;
        float pixelHeight = drawable_sprite.rect.height;
        float unitsToPixels = pixelWidth / drawable_sprite.bounds.size.x * transform.localScale.x;

        float centered_x = local_pos.x * unitsToPixels + pixelWidth / 2;
        float centered_y = local_pos.y * unitsToPixels + pixelHeight / 2;

        Vector2 pixel_pos = new Vector2(Mathf.RoundToInt(centered_x), Mathf.RoundToInt(centered_y));

        return pixel_pos;
    }

    private void ColourBetween(Vector2 start_point, Vector2 end_point, int width, Color color)
    {
        float distance = Vector2.Distance(start_point, end_point);
        Vector2 direction = (start_point - end_point).normalized;

        Vector2 cur_position = start_point;
        float lerp_steps = 1 / distance;

        for (float lerp = 0; lerp <= 1; lerp += lerp_steps)
        {
            cur_position = Vector2.Lerp(start_point, end_point, lerp);
            MarkPixelsToColour(cur_position, width, color);
        }
    }

    private void MarkPixelsToColour(Vector2 center_pixel, int pen_thickness, Color color_of_pen)
    {
        int center_x = (int)center_pixel.x;
        int center_y = (int)center_pixel.y;

        for (int x = center_x - pen_thickness; x <= center_x + pen_thickness; x++)
        {
            if (x >= (int)drawable_sprite.rect.width || x < 0)
                continue;

            for (int y = center_y - pen_thickness; y <= center_y + pen_thickness; y++)
            {
                if (y >= 0 && y < (int)drawable_sprite.rect.height)
                {
                    MarkPixelToChange(x, y, color_of_pen);
                }
            }
        }
    }
    private void MarkPixelToChange(int x, int y, Color color)
    {
        int array_pos = y * (int)drawable_sprite.rect.width + x;

        if (array_pos >= 0 && array_pos < cur_colors.Length)
        {
            cur_colors[array_pos] = color;
        }
    }

    private void ApplyMarkedPixelChanges()
    {
        drawable_texture.SetPixels32(cur_colors);
        drawable_texture.Apply();
    }







}