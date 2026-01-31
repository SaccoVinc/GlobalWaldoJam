using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] int quantity;

    private static List<GameObject> _characters = new List<GameObject>();
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera camera = Camera.main;
        Vector2 border = new Vector2(camera.orthographicSize * camera.aspect, camera.orthographicSize);
        
        for (int i = 0; i < quantity; i++)
        {
            Vector3 position = new Vector3
            {
                x = Random.Range(-border.x, border.x),
                y = Random.Range(-border.y, border.y),
                z = 0
            };
            GameObject characterInstance = Instantiate(character, position, Quaternion.identity) as GameObject;
            characterInstance.transform.parent = transform;
            _characters.Append(characterInstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveInstance(GameObject characterInstance)
    {
        
    }
}

