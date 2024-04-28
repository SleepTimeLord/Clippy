using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandle : MonoBehaviour
{
    private Camera _mainCamera;
    private SpriteRenderer sr;
    public GameObject canvas;
    private bool isCanvasVisible = false;

    private void Awake()
    {
        _mainCamera = Camera.main;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isCanvasVisible)
        {
            HideCanvas();
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        if (rayHit.collider.CompareTag("test1"))
        {
            ToggleCanvas();
        }
        else if (isCanvasVisible)
        {
            HideCanvas();
        }
    }

    private void ToggleCanvas()
    {
        isCanvasVisible = !isCanvasVisible;
        canvas.SetActive(isCanvasVisible);
    }

    private void HideCanvas()
    {
        isCanvasVisible = false;
        canvas.SetActive(false);
    }
}
