using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] List<GameObject> characters;
    [SerializeField] int quantity = 20;
    
    [SerializeField] private float minMovementDistance = 1;
    [SerializeField] private float maxMovementDistance = 5
    
    [SerializeField] private float minMovementSpeed = 1;
    [SerializeField] private float maxMovementSpeed = 2;

    [SerializeField] private float minTimeWait = 0.5f;
    [SerializeField] private float maxTimeWait = 2;
    
    [SerializeField] private float padding = 5;
    
    private static Camera _camera;
    private static Vector3 _border;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
        _border = new Vector2(_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
        _border -= new Vector3(padding, padding, 0.0f);
        
        for (int i = 0; i < quantity; i++)
        {
            Vector3 position = new Vector3
            {
                x = Random.Range(-_border.x, _border.x),
                y = Random.Range(-_border.y, _border.y),
                z = 0
            };
            int index = Random.Range(0, characters.Count);
            GameObject characterInstance = Instantiate(characters[index], position, Quaternion.identity) as GameObject;
            characterInstance.transform.parent = transform;
            MoveInstance(characterInstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveInstance(GameObject characterInstance)
    {
        // Generate random direction using angle
        float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle), 0);
        
        float movementDistance = Random.Range(minMovementDistance, maxMovementDistance);
        Vector3 newPosition = direction * movementDistance;
        
        newPosition += characterInstance.transform.position;
        
        newPosition.x = Mathf.Clamp(newPosition.x, -_border.x, _border.x);
        newPosition.y = Mathf.Clamp(newPosition.y, -_border.y, _border.y);
        
        characterInstance.transform.DOMove(newPosition, Random.Range(movementDistance/maxMovementSpeed, movementDistance/minMovementSpeed), false)
            .OnStart(
                () =>
                {
                    characterInstance.GetComponent<Animator>().SetBool("isWalking",true);
                }
            )
            .OnComplete( 
            () => {
                StartCoroutine(WaitInstance(characterInstance));
            });
    }

    IEnumerator WaitInstance(GameObject characterInstance)
    {
        characterInstance.GetComponent<Animator>().SetBool("isWalking",false);
        yield return new WaitForSeconds(Random.Range(minTimeWait, maxTimeWait));
        MoveInstance(characterInstance);
    }
}
