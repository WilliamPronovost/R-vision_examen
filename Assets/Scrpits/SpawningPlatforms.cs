using UnityEngine;

public class SpawningPlatforms : MonoBehaviour
{
    [SerializeField] private GameObject m_platformPrefab;
    [SerializeField] private Transform m_player;
    [SerializeField] private float m_interval;
	[SerializeField] private float m_distanceFromPlayer;
    private float m_heightOfNextPlatform;
    private float m_lastX;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        m_heightOfNextPlatform = m_interval;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_heightOfNextPlatform - m_player.position.y < m_distanceFromPlayer)
        {
            SpawnPlatform(m_heightOfNextPlatform);
            m_heightOfNextPlatform += m_interval;
        }
    }

    // Fonction SpawnPlatform pour generer les platformes a des emplacements aleatoires dans un axe specifique ((exemple si-dessous avec l'axe des x) a revoir) 
    private void SpawnPlatform(float spawnHeight)
    {
        float x = Random.Range(-13f, 13f);
		x = Mathf.Clamp(x + m_lastX, -5f, 5f);
        Vector3 spawnPosition = new Vector3(x, spawnHeight, 0);
        Instantiate(m_platformPrefab, spawnPosition, Quaternion.identity);
        m_lastX = x;
    }
}
