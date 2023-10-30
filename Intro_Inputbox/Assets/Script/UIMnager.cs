using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMnager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _input;
    [SerializeField]
    public TMP_Text _instructionText;
    [SerializeField]
    public TMP_Text _attemptsText;
    [SerializeField]
    private Button button;
    [SerializeField]
    private TMP_Text _button;
    [SerializeField]
    private GameManaer gameManager;
    [SerializeField]
    private GameObject _updateLife;

    [SerializeField]
    private Image imageComponent;
    /*[SerializeField]
    private Sprite trueImage;
    [SerializeField]
    private Sprite falseImage;*/
    public bool condition = true;
    private UpdateLife life;


    private void Awake()
    {
        life = _updateLife.GetComponent<UpdateLife>();
    }

    // Start is called before the first frame update
    void Start()
    {
       // button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);


        // Attach the input field's submit event listener (for Enter key press)
        _input.onEndEdit.AddListener(OnInputFieldEndEdit);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetUI()
    {
        _instructionText.text = "Guess a number between 1 and 100.";
        _attemptsText.text = "Attempts left: 5";
        _input.text = "";
    }

    public int GetPlayerGuess()
    {
        if (int.TryParse(_input.text, out int guess))
        {
            return guess;
        }
        return -1; // Return an invalid guess.
    }

    
    private void OnButtonClick()
    {
        //Debug.Log("Button Clicked!");
        gameManager.MakeGuess(int.Parse(_input.text));
        //gameManager.uiManager.ResetUI();


    }

    private void OnInputFieldEndEdit(string value)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
           // gameManager.uiManager.ResetUI();
            gameManager.MakeGuess(int.Parse(_input.text));

        }
    }

    public void UpdateUIImage(Sprite imge)
    {
       // Debug.Log("From uodate :" + imge);
        imageComponent.sprite = imge;

        //imageComponent.sprite = falseImage;

    }
   
    public void UpdateLifeImage(int attempts)
    {

        // _updateLife.GetComponent<UpdateLife>().UpdateUIImages(attempts);
        life.UpdateUIImages(attempts);
    }

    public void intializeLife(int attempts)
    {
        Debug.Log("UI Intialize life");
        //_updateLife.GetComponent<UpdateLife>().CreateUIImages(attempts);
       life.CreateUIImages(attempts);
    }
    public void GameOver(bool val)
    {
       // _gameOver.gameObject.SetActive(val);
    }


}
