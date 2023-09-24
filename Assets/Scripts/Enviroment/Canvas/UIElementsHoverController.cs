using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIElementsHoverController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("====Settings====")]
    [SerializeField] Transform _toScale;
    [Space(5)]
    [SerializeField] bool _resetScaleOnClick = true;
    [Range(1, 2)]
    [SerializeField] float _onHoverEnterScale = 1.2f;
    [Range(1, 2)]
    [SerializeField] float _onHoverExitScale = 1;
    [Space(5)]
    [Range(0, 1)]
    [SerializeField] float _scaleTime = 0.1f;


    public void OnPointerEnter(PointerEventData eventData)
    {
        _toScale.LeanScale(Vector2.one * _onHoverEnterScale, _scaleTime);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _toScale.LeanScale(Vector2.one * _onHoverExitScale, _scaleTime);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(_resetScaleOnClick)
            _toScale.LeanScale(Vector2.one * _onHoverExitScale, _scaleTime);
    }
}
