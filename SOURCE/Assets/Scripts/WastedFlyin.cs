using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WastedFlyin : MonoBehaviour
{
    [SerializeField] private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect.DOAnchorPos(new Vector2(0,0), 1f);
    }
}
