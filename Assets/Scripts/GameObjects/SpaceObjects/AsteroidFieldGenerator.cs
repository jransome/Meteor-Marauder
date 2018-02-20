using System.Collections.Generic;
using UnityEngine;

public class AsteroidFieldGenerator : MonoBehaviour {

	public GameObject AsteroidPrefab;
	public int AsteroidFrequency = 30;
    public Vector2 FieldDimensions = new Vector2(30f, 30f);

    private Transform cameraTransform;
    private Vector2 cameraPosition;
    private List<Rect> existingFields = new List<Rect>();

	void Start()
    {
        cameraTransform = Camera.main.gameObject.transform;
        Vector2 xOffset = Vector2.right * FieldDimensions.x;
        Vector2 yOffset = Vector2.up * FieldDimensions.y;

        CreateAsteroidField(cameraPosition);
        CreateAsteroidField(cameraPosition - xOffset + yOffset); // top-left
        CreateAsteroidField(cameraPosition + yOffset); // top
        CreateAsteroidField(cameraPosition + xOffset + yOffset); // top-right
        CreateAsteroidField(cameraPosition + xOffset); // right
        CreateAsteroidField(cameraPosition + xOffset - yOffset); // bottom-right
        CreateAsteroidField(cameraPosition - yOffset); // bottom
        CreateAsteroidField(cameraPosition - xOffset - yOffset); // bottom-left
        CreateAsteroidField(cameraPosition - xOffset); // left
    }

    private void CreateAsteroidField(Vector2 centrePosition)
    {
        Vector2 rectPosition = centrePosition - (FieldDimensions /2);
        Rect boundaryRect = new Rect(rectPosition, FieldDimensions);
        SpawnAsteroids(boundaryRect);
        existingFields.Add(boundaryRect);
    }

    private void Update()
    {
        cameraPosition = cameraTransform.position;
        //Debug.Log(cameraPosition);
        //float height = Camera.main.orthographicSize * 2;
        //float width = height * Camera.main.aspect;
        //Debug.Log("height - " + height + "width - " + width);
    }

    private void SpawnAsteroids(Rect fieldRect)
    {
        for (int i = 0; i < AsteroidFrequency; i++)
        {
            float xCoord = Random.Range(fieldRect.xMin, fieldRect.xMax);
            float yCoord = Random.Range(fieldRect.yMin, fieldRect.yMax);
            InstantiateAsteroid(xCoord, yCoord);
        }
    }

    private void InstantiateAsteroid(float xCoord, float yCoord)
    {
        int randomAngle = Random.Range(0, 360);
        Quaternion randomRotation = Quaternion.Euler(0, 0, randomAngle);
        Vector2 location = new Vector2(xCoord, yCoord);
        Instantiate(AsteroidPrefab, location, randomRotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        foreach (Rect fieldRect in existingFields)
        {
            Gizmos.DrawWireCube(fieldRect.center, new Vector3(FieldDimensions.x, FieldDimensions.y, 0f));
        }
    }
}
