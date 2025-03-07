using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemFieldUI : MonoBehaviour
{
    public ItemSO itemSO;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    public void SetVisual()
    {
        image.sprite = itemSO.Sprite;
        textMeshPro.text = itemSO.Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
