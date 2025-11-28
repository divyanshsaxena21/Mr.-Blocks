using System.Collections;
using UnityEngine;

public class FallingPillar : MonoBehaviour
{
    public GameObject pillar;  // The pillar object
    public float fallSpeed = 10f;  // Speed at which the pillar grows
    public float riseSpeed = 2f;   // Speed at which the pillar shrinks back
    public float fallDuration = 1f;  // Time duration for the pillar to grow (fall effect)
    public float riseDuration = 5f;  // Time duration for the pillar to shrink back
    public Vector3 initialScale;     // Original scale of the pillar
    public Vector3 maxScale;         // Max size the pillar reaches during the grow (fall) phase (set in Inspector)
    public float cycleSpeedMultiplier = 1f; // Multiplier to adjust the speed of the entire cycle

    private bool isGrowing = false;  // State for growing (fall)
    private bool isShrinking = false;   // State for shrinking (rise)
    private float growTimer = 0f;    // Timer for growing
    private float shrinkTimer = 0f;  // Timer for shrinking

    void Start()
    {
        // Save the initial scale of the pillar
        initialScale = pillar.transform.localScale;
        StartCoroutine(CycleGrowAndShrink());
    }

    void Update()
    {
        float adjustedFallDuration = fallDuration / cycleSpeedMultiplier;
        float adjustedRiseDuration = riseDuration / cycleSpeedMultiplier;

        if (isGrowing)
        {
            growTimer += Time.deltaTime;

            if (growTimer < adjustedFallDuration)
            {
                pillar.transform.localScale = Vector3.Lerp(initialScale, maxScale, growTimer / adjustedFallDuration);
                AdjustColliderSize();
            }
            else
            {
                isGrowing = false;
                isShrinking = true;
                growTimer = 0f;
            }
        }

        if (isShrinking)
        {
            shrinkTimer += Time.deltaTime;

            if (shrinkTimer < adjustedRiseDuration)
            {
                pillar.transform.localScale = Vector3.Lerp(pillar.transform.localScale, initialScale, shrinkTimer / adjustedRiseDuration);
                AdjustColliderSize();
            }
            else
            {
                isShrinking = false;
                shrinkTimer = 0f;
                StartCoroutine(CycleGrowAndShrink());
            }
        }
    }

    private IEnumerator CycleGrowAndShrink()
    {
        isGrowing = true;
        yield return new WaitForSeconds(fallDuration);
    }

    // Adjust the BoxCollider to match the pillar scaling
    private void AdjustColliderSize()
    {
        BoxCollider boxCollider = pillar.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            // Adjust only the Y-axis of the collider's size
            boxCollider.size = new Vector3(boxCollider.size.x, pillar.transform.localScale.y, boxCollider.size.z);

            // Adjust the center of the collider so the bottom remains fixed (scaling upwards)
            boxCollider.center = new Vector3(boxCollider.center.x, pillar.transform.localScale.y / 2, boxCollider.center.z);
        }
    }
}
