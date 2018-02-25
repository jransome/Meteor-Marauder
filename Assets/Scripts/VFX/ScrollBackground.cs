using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    public Transform cameraTransform;

    private Camera mainCamera;
    private MeshRenderer quadMeshRenderer;
    private Material quadMaterial;

    void Start()
    {
        mainCamera = Camera.main;
        quadMeshRenderer = GetComponent<MeshRenderer>();
        quadMaterial = quadMeshRenderer.material;
    }

    void Update()
    {
        ScrollBackgroundTexture();
        //FitQuadToCamera(); // commented becasue kind of unnecessary, just made quad big instead
    }

    void ScrollBackgroundTexture()
    {
        Vector2 newOffset = new Vector2(
            cameraTransform.position.x / transform.localScale.x, //dividing by local scale compensates for the scale of quad and 
            cameraTransform.position.y / transform.localScale.y  //scrolls the texture at the same rate at which the camera moves
        );

        quadMaterial.SetTextureOffset("_MainTex", newOffset);
    }

    void FitQuadToCamera()
    {
        float cameraViewHeight = mainCamera.orthographicSize * 2;
        float cameraViewWidth = cameraViewHeight * mainCamera.aspect;
        transform.localScale = Vector2.one * Mathf.Max(cameraViewHeight, cameraViewWidth); // avoids texture stretching out on just 1 axis by ensuring quad is always square 
    }
}
