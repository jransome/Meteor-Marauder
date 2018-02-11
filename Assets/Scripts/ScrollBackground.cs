using UnityEngine;

public class ScrollBackground : MonoBehaviour {

    public Transform cameraTransform;
    MeshRenderer quadMeshRenderer;
    Material quadMaterial;

    void Start()
    {
        quadMeshRenderer = GetComponent<MeshRenderer>();
        quadMaterial = quadMeshRenderer.material;
    }

    void Update()
    {
        Vector2 newOffset = new Vector2(
            cameraTransform.position.x / transform.localScale.x, //dividing by local scale compensates for the scale of quad and 
            cameraTransform.position.y / transform.localScale.y  //scrolls the texture at the same rate at which the camera moves
        );

        quadMaterial.SetTextureOffset("_MainTex", newOffset);
    }
}
