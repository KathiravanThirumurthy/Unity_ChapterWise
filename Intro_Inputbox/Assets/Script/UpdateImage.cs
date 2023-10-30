using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateImage :MonoBehaviour
{
    [SerializeField]
    private Image imageComponent;
    [SerializeField]
    private Sprite trueImage;
    [SerializeField]
    private Sprite falseImage;
    public bool condition = true;   
    // Start is called before the first frame update
    void Start()
    {
       // UpdateUIImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Function to update the image based on the condition
    private void UpdateUIImage(string imge)
    {
        
           // imageComponent.sprite = imge;
      
            //imageComponent.sprite = falseImage;
       
    }
}
