using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class RadialMenu : MonoBehaviour
{
    [SerializeField]
    GameObject EntryPreFab;

    [SerializeField]
    float Radius = 2.4f;

    [SerializeField]
    List<Texture> Icons;

    [SerializeField]
    List<string> ButtonNames;

    List<RadialMenuEntry> Entries;
    
    [SerializeField]
    int NumberOfEntries;

    [SerializeField]
    float DelayAmount = 0.04f;

    void Start () {
        Entries = new List<RadialMenuEntry>();
    }

    void AddEntry(string pLabel, Texture pIcon) {
        GameObject entry = Instantiate(EntryPreFab, transform);

        RadialMenuEntry rme = entry.GetComponent<RadialMenuEntry>();
        rme.SetLabel(pLabel);
        rme.SetIcon(pIcon);

        Entries.Add(rme);
    }

    public void Open() {

        for(int i=0; i<NumberOfEntries; i++){
            AddEntry(ButtonNames[i], Icons[i]);
        }

        Rearrange();

    }

    public void Close() {

        for(int i=0; i<NumberOfEntries; i++){
            RectTransform rect = Entries[i].GetComponent<RectTransform>();
            GameObject entry = Entries[i].gameObject;

            rect.DOScale(Vector3.zero, .3f).SetEase(Ease.OutQuad);
            rect.DOAnchorPos(Vector3.zero, .3f).SetEase(Ease.OutQuad).onComplete =
            delegate(){
                Destroy(entry);
            };
        };

        Entries.Clear();

    }


    public void Toggle() {
        if(Entries.Count == 0) {
            Open();
        } else {
            Close();
        }
    }


    void Rearrange() {
        float radiansOfSeperation = (Mathf.PI * 2) / Entries.Count;
        for(int i = 0; i < Entries.Count; i++) {
            float x = Mathf.Sin(radiansOfSeperation * i) * Radius;
            float y = Mathf.Cos(radiansOfSeperation * i) * Radius;

            RectTransform rect = Entries[i].GetComponent<RectTransform>();

            rect.localScale = Vector3.zero;
            rect.DOScale(Vector3.one, .3f).SetEase(Ease.OutQuad).SetDelay(.05f * i);
            rect.DOAnchorPos(new Vector3(x, y, 0), .3f).SetEase(Ease.OutQuad).SetDelay(DelayAmount * i);
        }

    }

   
}
