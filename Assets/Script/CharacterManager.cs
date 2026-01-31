using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] int quantity;

    private static List<GameObject> _characters = new List<GameObject>();
    private static Camera _camera;
    private static Vector3 _border;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
        _border = new Vector2(_camera.orthographicSize * _camera.aspect, _camera.orthographicSize);
        
        for (int i = 0; i < quantity; i++)
        {
            Vector3 position = new Vector3
            {
                x = Random.Range(-_border.x, _border.x),
                y = Random.Range(-_border.y, _border.y),
                z = 0
            };
            GameObject characterInstance = Instantiate(character, position, Quaternion.identity) as GameObject;
            characterInstance.transform.parent = transform;
            MoveInstance(characterInstance);
            _characters.Add(characterInstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveInstance(GameObject characterInstance)
    {
        Vector3 newPosition = new Vector3
        {
            x = Random.Range(-2, 2),
            y = Random.Range(-2, 2),
            z = 0
        };
        newPosition += characterInstance.transform.position;
        characterInstance.transform.DOMove(newPosition, Random.Range(3.0f, 10.0f), false).OnComplete( 
            () => {
                DOTween.Kill(characterInstance);
                StartCoroutine(WaitInstance(characterInstance));
            });
        
        DOTween.Play(characterInstance);
    }

    IEnumerator WaitInstance(GameObject characterInstance)
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
        MoveInstance(characterInstance);
    }
}
