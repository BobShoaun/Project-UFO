using System.Collections;
using UnityEngine;

public class CopSpawner : MonoBehaviour {

    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float yMax;
    [SerializeField] private Cop copPrefab;
    [SerializeField] private UFO player;
    [SerializeField] private PoliceCar policeCarPrefab;

    private float GetMidPoint() { return (xMin + xMax) / 2; }

    private void Start() {
        StartCoroutine(SpawnCops());
        StartCoroutine(SpawnPoliceCar());
    }

    private IEnumerator SpawnCops()
    {
        while (true) {
            yield return new WaitForSeconds(1);

            var xPos = Random.Range(xMin, xMax);
            var yPos = Random.Range(yMin, yMax);

            Vector2 pos;

            if (xPos > GetMidPoint())
            {
                pos = new Vector2(xMax, yPos);
            }
            else
            {
                pos = new Vector2(xMin, yPos);
            }

            Cop c = Instantiate(copPrefab, pos, Quaternion.identity);
            c.target = player.transform;
            c.targetPosition = new Vector2(xPos, yPos);


        }
    }

    private IEnumerator SpawnPoliceCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            var xPos = Random.Range(xMin, xMax);
            var yPos = Random.Range(yMin, yMax);

            Vector2 pos;

            if (xPos > GetMidPoint())
            {
                pos = new Vector2(xMax, yPos);
            }
            else
            {
                pos = new Vector2(xMin, yPos);
            }

            PoliceCar c = Instantiate(policeCarPrefab, pos, Quaternion.identity);
            c.targetPosition = new Vector2(xPos, yPos);
        }
    }

}
