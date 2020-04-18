using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    float multiplier = 0.0f;

    [SerializeField]
    bool horizontalOnly = false;

    private Transform cameraTransform;

    private Vector3 startCameraPos;
    private Vector3 startPos;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        startCameraPos = cameraTransform.position;
        startPos = transform.position;
    }

    private void LateUpdate()
    {
        var position = startPos;

        if (horizontalOnly)
            position.x += multiplier * (cameraTransform.position.x - startCameraPos.x);
        else
            position += multiplier * (cameraTransform.position - startCameraPos);

        transform.position = position;
    }
}
