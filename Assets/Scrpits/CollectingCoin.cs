using UnityEngine;

public class CollectingCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        //� revoir
        PlayerControls player = collision.GetComponent<PlayerControls>();
        if(player != null){
            Destroy(gameObject);
        }
    }
}
