using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _effect;
    private PauseManager _pauseManager;
    private UIManager _uiManager;
    private int points = 5;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _pauseManager = FindObjectOfType<PauseManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {

        string tagObject = gameObject.tag;
        Debug.Log(_pauseManager);
        if (tagObject == "Bad")
        {
           _pauseManager.TogglePause();

        }
        else
        {
            Destroy(this.gameObject);
            Instantiate(_effect, transform.position, Quaternion.identity);
            _uiManager.IncreaseScore(points);
        }


    }
}
