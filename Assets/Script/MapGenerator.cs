using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int width = 10; // �������ҧ�ͧἹ���
    public int height = 10; // �����٧�ͧἹ���
    public GameObject[] tiles; // Prefabs �ͧ Tile ��ҧ � (�ҡ���ҧ� Inspector)

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
                // ���� Tile �������ҧ
                GameObject tile = tiles[Random.Range(0, tiles.Length)];

                // ���ҧ Tile �� Grid
                Instantiate(tile, new Vector2(x, y), Quaternion.identity);
            }
        }
    }
}
