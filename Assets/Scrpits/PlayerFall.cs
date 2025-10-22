using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFall : MonoBehaviour
{
	private void OnTriggerEnter(Collider collision)
	{
		PlayerControls player = collision.GetComponent<PlayerControls>();
		if(player != null)
		{
			Destroy(player);
			SceneManager.LoadScene("TestScene");
		}
	}
}
