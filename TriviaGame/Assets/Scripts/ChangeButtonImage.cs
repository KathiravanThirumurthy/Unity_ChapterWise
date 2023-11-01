using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonImage : MonoBehaviour
{
    public Sprite normalSprite;       // The normal image
    public Sprite highlightedSprite;  // The image to display when the button is highlighted or pressed
    private Image buttonImage;        // Reference to the button's Image component
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonPressed()
    {
       
        buttonImage.sprite = highlightedSprite;
    }

    public void OnButtonReleased()
    {
        buttonImage.sprite = normalSprite;
    }
}
