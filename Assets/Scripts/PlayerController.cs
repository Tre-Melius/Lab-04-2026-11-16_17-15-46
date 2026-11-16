using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] Camera cam; 
    InputAction moveAction;
    Vector3 moveVector;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        if (cam == null) cam = Camera.main;
        if (cam == null) Debug.LogError("No camera found. Tag your camera MainCamera or assign it in the Inspector.");
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        transform.position += moveVector * moveSpeed * Time.deltaTime;

        if (cam != null) ClampToScreen();
    }

    void ClampToScreen()
    {
        // distance from camera to player (needed for perspective cameras, harmless for orthographic)
        float depth = transform.position.z - cam.transform.position.z;

        Vector3 min = cam.ViewportToWorldPoint(new Vector3(0f, 0f, depth)); // bottom-left
        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1f, 1f, depth)); // top-right

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, min.x + padding, max.x - padding);
        pos.y = Mathf.Clamp(pos.y, min.y + padding, max.y - padding);
        transform.position = pos;
    }
}
