using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandle : MonoBehaviour
{
    private Camera _mainCamera;
    public SpriteRenderer sr;
    public GameObject canvas;
    nextscene sceneLoader = new nextscene();

    private void Awake()
    {
        _mainCamera = Camera.main;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        if (rayHit.collider.CompareTag("test1") && GameData.speechtest == false)
        {
            canvas.SetActive(true);
            GameData.speechtest = true;
        }
        else if (canvas == true)
        {
            canvas.SetActive(false);
        }

        if (rayHit.collider.CompareTag("nextscene") && GameData.speechtest == true)
        {
            sceneLoader.LoadScene("DBH Test");
        }
    }
}
