using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TileBehaviour : MonoBehaviour
{
    private int _id;
    private Color _defaultColor;
    private Color _clickedColor;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Init(int id,Color defaultColor, Color clickedColor)
    {
        _id = id;
        _defaultColor = defaultColor;
        _clickedColor = clickedColor;
    }

    private void OnMouseDown()
    {
        SetColorForAllMaterials(_clickedColor);
        Debug.Log(_id);
    }

    private void SetColorForAllMaterials(Color color)
    {
        foreach (var mat in _renderer.materials)
        {
            mat.color = _clickedColor;
        }
    }
}
