using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AsteroidFieldGenerator : MonoBehaviour {

	public GameObject AsteroidPrefab;
	public int AsteroidFrequency = 30;
    public Vector2 FieldDimensions = new Vector2(30f, 30f);

    private Transform cameraTransform;
    private List<Rect> existingFields = new List<Rect>();
    private Vector2 lastLocalFieldCentre;
    private Vector2 fieldWidthOffset;
    private Vector2 fieldHeightOffset;

    void Start()
    {
        cameraTransform = Camera.main.gameObject.transform;
        fieldWidthOffset = Vector2.right * FieldDimensions.x;
        fieldHeightOffset = Vector2.up * FieldDimensions.y;
        GenerateLocalFields(cameraTransform.position);
    }

    private void FixedUpdate()
    {
        Vector2 cameraPosition = cameraTransform.position;
        Vector2 localFieldCentre = existingFields.Find(field => field.Contains(cameraPosition)).center;

        if (localFieldCentre != lastLocalFieldCentre)
        {
            lastLocalFieldCentre = localFieldCentre;
            GenerateLocalFields(localFieldCentre);
        }
    }

    private void GenerateLocalFields(Vector2 localFieldCentre)
    {
        List<Vector2> adjacentFieldCentres = new List<Vector2>
        {
            localFieldCentre,
            localFieldCentre + fieldHeightOffset,
            localFieldCentre - fieldHeightOffset,
            localFieldCentre + fieldWidthOffset,
            localFieldCentre - fieldWidthOffset,
            localFieldCentre + fieldWidthOffset + fieldHeightOffset,
            localFieldCentre - fieldWidthOffset - fieldHeightOffset,
            localFieldCentre - fieldWidthOffset + fieldHeightOffset,
            localFieldCentre + fieldWidthOffset - fieldHeightOffset,
        };

        List<Vector2> missingFieldCentres = adjacentFieldCentres.Where(afc => existingFields.All(ef => ef.center != afc)).ToList();

        foreach (Vector2 missingFieldCentre in missingFieldCentres)
        {
            CreateAsteroidField(missingFieldCentre);
        }
    }

    private void CreateAsteroidField(Vector2 centrePosition)
    {
        Vector2 rectPosition = centrePosition - (FieldDimensions / 2);
        Rect boundaryRect = new Rect(rectPosition, FieldDimensions);
        SpawnAsteroids(boundaryRect);
        existingFields.Add(boundaryRect);
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

    // For visual debugging in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        foreach (Rect fieldRect in existingFields)
        {
            Gizmos.DrawWireCube(fieldRect.center, new Vector3(FieldDimensions.x, FieldDimensions.y, 0f));
        }
    }
}
