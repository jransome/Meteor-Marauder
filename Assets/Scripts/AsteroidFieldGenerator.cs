using UnityEngine;

public class AsteroidFieldGenerator : MonoBehaviour {

	public GameObject AsteroidPrefab;
	public int AsteroidFrequency = 10;
    public Vector2 GridDimensions = new Vector2(10, 10);

    private float asteroidDiameter;
    private int gridSquares;

	void Start()
    {
        asteroidDiameter = AsteroidPrefab.GetComponent<CircleCollider2D>().radius;
        gridSquares = (int)(GridDimensions.x * GridDimensions.y);
        SpawnAsteroidField();
    }

    private void SpawnAsteroidField()
    {
        for (int i = 0; i < AsteroidFrequency; i++)
        {
            InstantiateAsteroid(i, i);
        }
    }

    private void InstantiateAsteroid(float xCoord, float yCoord)
    {
        int randomAngle = Random.Range(0, 200);
        Quaternion randomRotation = Quaternion.Euler(0, 0, randomAngle);
        Vector2 location = new Vector2(xCoord, yCoord);
        Instantiate(AsteroidPrefab, location, randomRotation);
    }

}
