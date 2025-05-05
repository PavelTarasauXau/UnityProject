using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    void Start()
    {
        spawnedChunks.Add(FirstChunk);
        SpawnChunk();
    }

    void Update()
    {
        // ���� ����� ������������ � ����� �������������� �����, ������� ����� ����
        if (spawnedChunks.Count >= 2 &&
            Player.position.z > spawnedChunks[spawnedChunks.Count - 2].End.position.z - 60)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);

        // �������� ��������� ����
        Chunk lastChunk = spawnedChunks[spawnedChunks.Count - 1];

        // ��������� �������� ����� Begin � ������� ������ �����
        Vector3 offset = newChunk.transform.position - newChunk.Begin.position;

        // ������������� ������� ������ ����� ���, ����� ��� Begin ������ � End ���������� �����
        newChunk.transform.position = lastChunk.End.position + offset;

        spawnedChunks.Add(newChunk);

        // ������� ������ �����, ���� �� ������ 3 (����� ������ ���� 2 ������� + �������)
        /*if (spawnedChunks.Count > 5)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }*/
    }
}