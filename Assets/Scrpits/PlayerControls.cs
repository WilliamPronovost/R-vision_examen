using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float m_playerSpeed;
    [SerializeField] private float m_playerJumpForce;
    [SerializeField] private InputActionAsset m_inputActions;
    private bool m_isOnGround = true;
    private InputAction m_moveAction;
    private InputAction m_jumpAction;
    private Rigidbody m_playerRigidbody;
    private Vector3 m_moveAmt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_moveAction = m_inputActions.FindAction("Move");
        m_jumpAction = m_inputActions.FindAction("Jump");

        m_playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        m_moveAmt = m_moveAction.ReadValue<Vector2>().normalized;

        // Déplacement sans physique

        transform.Translate(new Vector3(m_moveAmt.x, 0, m_moveAmt.y) * m_playerSpeed * Time.deltaTime);

        bool jumpButtonPressed = m_jumpAction.WasPressedThisFrame();
        if (jumpButtonPressed && m_isOnGround)
        {
            m_playerRigidbody.AddForce(Vector3.up * m_playerJumpForce, ForceMode.Impulse);
            m_isOnGround = false;
        }

        // Application des layers(à revoir)
        if(m_playerRigidbody.linearVelocity.y >= Mathf.Epsilon)
        {
            gameObject.layer = LayerMask.NameToLayer("Platform");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        m_isOnGround = true;
    }
    private void Moving()
    {
        // Déplacement avec physique(à revoir)
        Vector3 calculatedVelocity = m_playerRigidbody.linearVelocity;
        calculatedVelocity.x = m_moveAmt.x * m_playerSpeed;
        calculatedVelocity.z = m_moveAmt.y * m_playerSpeed;
        m_playerRigidbody.linearVelocity = calculatedVelocity;
    }
}
