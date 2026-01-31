using UnityEngine;

public class RandomizeCharacter : MonoBehaviour
{
    [Header("Renderers - Main")]
    [SerializeField] SpriteRenderer Head;
    [SerializeField] SpriteRenderer Body;

    [Header("Renderers - Limbs")]
    [SerializeField] SpriteRenderer LeftArm;
    [SerializeField] SpriteRenderer RightArm;
    [SerializeField] SpriteRenderer LeftLeg;
    [SerializeField] SpriteRenderer RightLeg;

    [Header("Sprite Pools")]
    [SerializeField] Sprite[] HeadSprites;
    [SerializeField] Sprite[] ArmSprites; 
    [SerializeField] Sprite[] LegSprites;
    [SerializeField] Sprite[] BodySprites;

    [Header("Color Settings")]
    [SerializeField] Color[] AvailableColors;

    void Start()
    {
        Randomize();
    }

    [ContextMenu("Randomize Character")]
    public void Randomize()
    {
        if (HeadSprites.Length > 0)
            Head.sprite = HeadSprites[Random.Range(0, HeadSprites.Length)];

        if (BodySprites.Length > 0)
            Body.sprite = BodySprites[Random.Range(0, BodySprites.Length)];

        if (ArmSprites.Length > 0)
        {
            int rndArmIndex = Random.Range(0, ArmSprites.Length);
            Sprite selectedArm = ArmSprites[rndArmIndex];

            LeftArm.sprite = selectedArm;
            RightArm.sprite = selectedArm;
        }

        if (LegSprites.Length > 0)
        {
            int rndLegIndex = Random.Range(0, LegSprites.Length);
            Sprite selectedLeg = LegSprites[rndLegIndex];

            LeftLeg.sprite = selectedLeg;
            RightLeg.sprite = selectedLeg;
        }

        if (AvailableColors.Length > 0)
        {
            Color randomColor = AvailableColors[Random.Range(0, AvailableColors.Length)];

            Head.color = randomColor;
            Body.color = randomColor;

            LeftArm.color = randomColor;
            RightArm.color = randomColor;

            LeftLeg.color = randomColor;
            RightLeg.color = randomColor;
        }
    }
}