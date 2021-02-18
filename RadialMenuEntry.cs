using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

//public delegate void RadialMenuDelegate(RadialMenuEntry pEntry);

public class RadialMenuEntry : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public delegate void RadialMenuEntryDelegate(RadialMenuEntry pEntry);

    [SerializeField]
    TextMeshProUGUI Label;

    [SerializeField]
    RawImage Icon;

    [SerializeField]
    float ScaleSize;

    RectTransform Rect;


    RadialMenuEntryDelegate Callback;


    private void Start(){
        Rect = GetComponent<RectTransform>();
    }

    public void SetLabel(string pText) {
        Label.text = pText;
    }

    public string GetLabel() {
        return (Label.text);
    }

    public void SetIcon(Texture pIcon) {
        Icon.texture = pIcon;
    }

    public Texture GetIcon() {
        return (Icon.texture);
    }


    public void SetCallback(RadialMenuEntryDelegate pCallback){
        Callback = pCallback;
    }

    public void OnPointerClick(PointerEventData eventData) {
        //comments
        Callback?.Invoke(this);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Rect.DOComplete();
        Rect.DOScale(Vector3.one * ScaleSize, .3f).SetEase(Ease.OutQuad);
    }

    public void OnPointerExit(PointerEventData eventData) {
        Rect.DOComplete();
        Rect.DOScale(Vector3.one, .3f).SetEase(Ease.OutQuad);
    }


}
