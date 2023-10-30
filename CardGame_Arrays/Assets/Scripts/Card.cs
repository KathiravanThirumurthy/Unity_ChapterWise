using UnityEngine;

public class Card : MonoBehaviour
{
    // Symbol associated with the card
    public string symbol;

    // Indicates if the card is matched
    public bool IsMatched { get;  set; }
    // Tracks the card's rotation state
    private bool isFlipped = false;
    // Stores the initial rotation of the card
    private Quaternion initialRotation; 

     private void Start()
    {
        // Store the initial rotation of the card
        initialRotation = transform.rotation;
    }

    // Function to flip the card to its front
    public void FlipToFront()
    {
        if (!isFlipped)
        {
            // Rotate the card to its front (for example, 180 degrees around the Y-axis)
            transform.rotation = Quaternion.Euler(0, 90, 0);
            isFlipped = true;
        }
    }

    // Function to flip the card to its back
    public void FlipToBack()
    {
        if (isFlipped)
        {
            // If the card is already flipped, return it to its initial rotation
            transform.rotation = initialRotation;
            isFlipped = false;
        }
    }

    // Function to mark the card as matched
    public void MarkAsMatched()
    {
        IsMatched = true;
    }

    // Function to reset the card
    public void ResetCard()
    {
        IsMatched = false;
        // Make sure the card is flipped to its back when reset
        FlipToBack(); 
    }
}
