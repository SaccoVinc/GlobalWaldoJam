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

    [Header("Color")]
    [SerializeField] Material customMaterial;
    
    [Header("Color Cloth")]
    [SerializeField] Color[] AvailableColorsCloth;
    
    
    [Header("Color Face")]
    [SerializeField] Color[] AvailableColorsFace;

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

        if (AvailableColorsCloth.Length > 0)
        {
            SpriteRenderer spriteRenderer = Body.GetComponent<SpriteRenderer>();
            spriteRenderer.material = customMaterial;
            
            spriteRenderer.material.SetColor("_ReplacementColor", AvailableColorsCloth[Random.Range(0, AvailableColorsCloth.Length)]);
        }
        if (AvailableColorsFace.Length > 0)
        {
            SpriteRenderer spriteRenderer = Head.GetComponent<SpriteRenderer>();
            spriteRenderer.material = customMaterial;
            SpriteRenderer LL = LeftLeg.GetComponent<SpriteRenderer>();
            LL.material = customMaterial;
            SpriteRenderer RL = RightLeg.GetComponent<SpriteRenderer>();
            RL.material = customMaterial;
            SpriteRenderer LA = LeftArm.GetComponent<SpriteRenderer>();
            LA.material = customMaterial;
            SpriteRenderer RA = RightArm.GetComponent<SpriteRenderer>();
            RA.material = customMaterial;

            Color color = AvailableColorsFace[Random.Range(0, AvailableColorsFace.Length)];
            
            spriteRenderer.material.SetColor("_ReplacementColor", color);
            LL.material.SetColor("_ReplacementColor", color);
            RL.material.SetColor("_ReplacementColor", color);
            LA.material.SetColor("_ReplacementColor", color);
            RA.material.SetColor("_ReplacementColor", color);
        }
    }
}