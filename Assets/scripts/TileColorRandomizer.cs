using UnityEngine;

public class TileColorRandomizer : MonoBehaviour
{
    [Header("Black Tiles")]
    [Tooltip("How many tiles should become black?")]
    public int numberOfBlackTiles = 5;  

    [Header("Paused Tiles")]
    [Tooltip("How many tiles should become paused tiles?")]
    public int numberOfPausedTiles = 5;  

    [Header("Red Tiles")]
    [Range(0f, 1f)]
    [Tooltip("What fraction of the remaining tiles should become red? e.g. 0.3 = 30%")]
    public int fractionRed = 30;

    void Start()
    {
        TileScript[] allTiles = GetComponentsInChildren<TileScript>();
        int totalTiles = allTiles.Length;
        if (totalTiles == 0)
        {
            Debug.LogWarning("No TileScript found under this GameObject!");
            return;
        }

        for (int i = 0; i < totalTiles; i++)
        {
            int randomIndex = Random.Range(i, totalTiles);
            // Swap
            TileScript temp = allTiles[i];
            allTiles[i] = allTiles[randomIndex];
            allTiles[randomIndex] = temp;
        }

        int actualBlackCount = Mathf.Min(numberOfBlackTiles, totalTiles);
        for (int i = 0; i < actualBlackCount; i++)
        {
            TileScript tile = allTiles[i];
            tile.isBlackTile = true;
            SpriteRenderer sr = tile.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = new Color32(0x00, 0x00, 0x00, 0xFF);
            }
        }

        int remainingAfterBlack = totalTiles - actualBlackCount;
        int actualPausedCount = Mathf.Min(numberOfPausedTiles, remainingAfterBlack);
        for (int i = actualBlackCount; i < actualBlackCount + actualPausedCount; i++)
        {
            TileScript tile = allTiles[i];
            tile.isPausedTile = true;
            SpriteRenderer sr = tile.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = new Color32(255, 11, 210, 255); // #FF0BD2
            }
        }

        float x = (fractionRed * totalTiles)/100;
        for (int i = actualBlackCount + actualPausedCount; i < x; i++)
        {
            TileScript tile = allTiles[i];
        
            tile.isRedTile = true;

            SpriteRenderer sr = tile.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = new Color32(0xA6, 0x10, 0x10, 0xFF);
            }
 
        }
    }
}
