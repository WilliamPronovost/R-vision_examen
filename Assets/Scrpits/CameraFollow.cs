using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform m_player;
    [SerializeField] private Vector3 m_offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = m_player.position - m_offset;

        // Pour que la camera suive uniquement le joueur dans un axe specifique (exemple si dessous avec l'axe des y)
        
        float height = m_player.position.y + m_offset.y;
        if (height < m_player.position.y)
            return;
        Vector3 pos = m_player.position;
        pos.y = height;
        m_player.position = pos;
    }
}
