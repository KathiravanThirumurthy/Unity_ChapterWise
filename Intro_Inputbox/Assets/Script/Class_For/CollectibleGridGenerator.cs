using UnityEngine;
using UnityEngine.UI;

public class CollectibleGridGenerator : MonoBehaviour
{
    // Reference to the collectible prefab.
    [SerializeField]
    private GameObject collectiblePrefab;
    [SerializeField]
    private GameObject _gameOverScreen;
    // Number of collectibles in the X-axis.
    public int gridWidth = 5;
    // Number of collectibles in the Y-axis.
    public int gridHeight = 5;
    // Spacing between collectibles.
    public float spacing = 2.0f;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text timeText;
    public float gameTime = 30.0f;  // Total game time in seconds

    private int score = 0;
    private float timeLeft;

    void Start()
    {
        GenerateCollectibleGrid();
        timeLeft = gameTime;
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            GameOver();
        }
        UpdateUI();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                // Check for collision with hitInfo.collider
                if (hitInfo.collider != null)
                {
                    // You can access the collider via hitInfo.collider
                    // Add your logic for 3D collision here
                    if (hitInfo.collider.CompareTag("Collectable"))
                    {
                        CollectItem(hitInfo.collider.gameObject);
                    }
                }
            }
        }
    }

    void CollectItem(GameObject item)
    {
        Destroy(item);
        score++;
        UpdateUI();
    }
    void GenerateCollectibleGrid()
    {
        /*float gridWidthOffset = (gridWidth - 1) * spacing / 2;
        float gridHeightOffset = (gridHeight - 1) * spacing / 2;*/

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                // Calculate the position for each collectible.
                float xPos = x * spacing;
                float yPos = y * spacing;

                // Instantiate a collectible at the calculated position.
                Vector3 position = new Vector3(xPos, yPos, 0);
                Instantiate(collectiblePrefab, position, Quaternion.identity);
            }
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        timeText.text = "Time: " + Mathf.Ceil(timeLeft);
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        _gameOverScreen.SetActive(true);
    }
}
