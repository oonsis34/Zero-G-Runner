using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int width = 10; // ความกว้างของแผนที่
    public int height = 10; // ความสูงของแผนที่
    public GameObject[] tiles; // Prefabs ของ Tile ต่าง ๆ (ลากมาวางใน Inspector)

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // สุ่ม Tile ที่จะสร้าง
                GameObject tile = tiles[Random.Range(0, tiles.Length)];

                // สร้าง Tile บน Grid
                Instantiate(tile, new Vector2(x, y), Quaternion.identity);
            }
        }
    }
}
