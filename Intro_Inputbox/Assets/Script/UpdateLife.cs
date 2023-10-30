using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UpdateLife : MonoBehaviour
{
    public Transform imageParent; // The parent object to hold the UI images
    public GameObject imagePrefab; // The prefab for the UI image
   // public int maxValue = 10; // The maximum value
    //public int currentValue = 5; // The current value
    public float horizontalSpacing = 10f;

    private List<GameObject> uiImages = new List<GameObject>();

    private void Start()
    {
        //CreateUIImages(int attempts);
    }

    public void CreateUIImages(int currentValue)
    {
        for (int i = 0; i < currentValue; i++)
        {
            //new Vector3(i * 2.0f, 0, 0),
            GameObject uiImage = Instantiate(imagePrefab, imageParent);
            float xPos = i * (horizontalSpacing + uiImage.GetComponent<RectTransform>().sizeDelta.x);
            uiImage.transform.localPosition = new Vector3(xPos, 0, 0);
            
            // Set the position and size of the UI images as needed
            uiImages.Add(uiImage);
        }
    }

    public void UpdateUIImages(int currentValue)
    {
        Debug.Log("Updage");
        for (int i = 0; i < uiImages.Count; i++)
        {
            if (i < currentValue)
            {
                // Set the UI image to be visible or change its appearance
                uiImages[i].SetActive(true);
            }
            else
            {
                // Set the UI image to be hidden or change its appearance
                uiImages[i].SetActive(false);
            }
        }
    }
}
