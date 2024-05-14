using UnityEngine;
using UnityEngine.InputSystem;

public class BluePaddleController : MonoBehaviour
{
    public float speed = 10f;
    private BluePaddleControls controls;
    private Vector2 moveInput;
    private float screenTop;
    private float screenBottom;

    private void Awake()
    {
        controls = new BluePaddleControls();
    }

    private void OnEnable()
    {
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        controls.Player.Enable();

        // Calculate screen bounds
        float cameraHeight = Camera.main.orthographicSize * 2f;
        screenTop = Camera.main.transform.position.y + Camera.main.orthographicSize;
        screenBottom = Camera.main.transform.position.y - Camera.main.orthographicSize;
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    void Update()
    {
        Vector2 position = transform.position;
        position.y += moveInput.y * speed * Time.deltaTime;

        // Clamp the paddle's position to stay within the screen bounds
        float paddleHeight = GetComponent<BoxCollider2D>().size.y / 2;
        position.y = Mathf.Clamp(position.y, screenBottom + paddleHeight, screenTop - paddleHeight);

        transform.position = position;
    }
}
