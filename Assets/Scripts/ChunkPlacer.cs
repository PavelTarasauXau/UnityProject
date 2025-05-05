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
        // ≈сли игрок приближаетс€ к концу предпоследнего чанка, спавним новый чанк
        if (spawnedChunks.Count >= 2 &&
            Player.position.z > spawnedChunks[spawnedChunks.Count - 2].End.position.z - 60)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);

        // ѕолучаем последний чанк
        Chunk lastChunk = spawnedChunks[spawnedChunks.Count - 1];

        // ¬ычисл€ем смещение между Begin и центром нового чанка
        Vector3 offset = newChunk.transform.position - newChunk.Begin.position;

        // ”станавливаем позицию нового чанка так, чтобы его Begin совпал с End последнего чанка
        newChunk.transform.position = lastChunk.End.position + offset;

        spawnedChunks.Add(newChunk);

        // ”дал€ем старые чанки, если их больше 3 (чтобы всегда было 2 впереди + текущий)
        /*if (spawnedChunks.Count > 5)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }*/
    }
}