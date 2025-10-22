using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private InputActionAsset m_inputFile;
    private InputAction m_inputAction;
    private string m_sceneName = "SampleScene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_inputAction = m_inputFile.FindAction("ChangeScene");
    }

    // Update is called once per frame
    void Update()
    {
		bool escapeButtonPressed = m_inputAction.WasPressedThisFrame();
		if (escapeButtonPressed)
		{
		    SceneManager.LoadScene(m_sceneName);
		}
    }
}
