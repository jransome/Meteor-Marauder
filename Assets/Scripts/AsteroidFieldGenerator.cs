using UnityEngine;

public class AsteroidFieldGenerator : MonoBehaviour {

	public GameObject AsteroidPrefab;
	public int AsteroidFrequency = 10;
    public Vector3 FieldCentrePosition = new Vector3(0f, 0f, 0f);
    public Vector2 FieldDimensions = new Vector2(10f, 10f);

    //private float asteroidDiameter;

	void Start()
    {
        //asteroidDiameter = AsteroidPrefab.GetComponent<CircleCollider2D>().radius;
        SpawnAsteroidField();
    }

    private void SpawnAsteroidField()
    {
        float fieldLeftBound = FieldCentrePosition.x - (FieldDimensions.x / 2);
        float fieldRightBound = FieldCentrePosition.x + (FieldDimensions.x / 2);
        float fieldTopBound = FieldCentrePosition.y + (FieldDimensions.y / 2);
        float fieldBottomBound = FieldCentrePosition.y - (FieldDimensions.y / 2);

        for (int i = 0; i < AsteroidFrequency; i++)
        {
            float xCoord = Random.Range(fieldLeftBound, fieldRightBound);
            float yCoord = Random.Range(fieldBottomBound, fieldTopBound);
            InstantiateAsteroid(xCoord, yCoord);
        }
    }

    private void InstantiateAsteroid(float xCoord, float yCoord)
    {
        int randomAngle = Random.Range(0, 200);
        Quaternion randomRotation = Quaternion.Euler(0, 0, randomAngle);
        Vector2 location = new Vector2(xCoord, yCoord);
        Instantiate(AsteroidPrefab, location, randomRotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(FieldCentrePosition, new Vector3(FieldDimensions.x, FieldDimensions.y, 0f));
    }
}
