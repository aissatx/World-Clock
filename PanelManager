using UnityEngine;

public class ClockPanelManager : MonoBehaviour
{
    public GameObject clockPrefab;   // Reference to the clock prefab
    public GameObject textPrefab;    // Reference to the TextMesh prefab for labels
    public Vector3 startPosition = new Vector3(-5, 5, 0);  // Position for the first clock (top-left)
    public float horizontalSpacing = 10f;  // Horizontal distance between clocks
    public float verticalSpacing = 10f;    // Vertical distance between clocks
    public float labelOffsetY = -1.5f;    // Vertical offset for labels relative to clocks

    public Sprite[] clockImages;  // Array to hold the images for each clock
    public GameObject imagePrefab;  // Prefab that contains a SpriteRenderer for the clock image

    private int[] timeZoneOffsets = new int[4] {
        0,    // UTC (Top-left)
        -7,   // PST (Top-right)
        -4,   // EST (Bottom-left)
        9     // JST (Bottom-right)
    };

    private string[] cityNames = new string[4] {
        "London",   // Top-left clock
        "California",   // Top-right clock
        "New York",   // Bottom-left clock
        "Tokyo"    // Bottom-right clock
    };

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            // Calculate row and column for clock placement
            int row = i / 2;
            int col = i % 2;

            // Calculate position for each clock
            Vector3 newPosition = startPosition + new Vector3(col * horizontalSpacing, -row * verticalSpacing, 0);

            // Instantiate the clock prefab at the calculated position
            GameObject newClock = Instantiate(clockPrefab, newPosition, Quaternion.identity);

            // Set the time zone offset for each clock
            Clock clockScript = newClock.GetComponent<Clock>();
            clockScript.timeZoneOffset = timeZoneOffsets[i];

            // Instantiate the image prefab behind the clock
            GameObject newImage = Instantiate(imagePrefab, newPosition, Quaternion.identity);
            SpriteRenderer spriteRenderer = newImage.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = clockImages[i];  // Assign the appropriate image from the array

            // Instantiate the label prefab (TextMesh) and position it below the clock
            Vector3 labelPosition = newPosition + new Vector3(0, labelOffsetY, 0);
            GameObject newLabel = Instantiate(textPrefab, labelPosition, Quaternion.identity);

            // Set the label's text to the correct city name
            TextMesh textMesh = newLabel.GetComponent<TextMesh>();
            textMesh.text = cityNames[i];
        }
    }
}
