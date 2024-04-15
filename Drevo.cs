using UnityEngine;
using DG.Tweening;

public class Drevo : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private Transform transformDrevo;
    [SerializeField] private Vector3 vector_rotacie;
    [SerializeField] private float cas_rotacie;
    void Start()
    {
        transformDrevo
            .DOLocalRotate(vector_rotacie, cas_rotacie, RotateMode.FastBeyond360)
            .SetLoops (-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    public void Hit(int keyIndex, float poskodenie) {
        float colliderVyska = 2.020738f;
        float vaha_nova = skinnedMeshRenderer.GetBlendShapeWeight (keyIndex) + poskodenie *(100f/ colliderVyska);
        skinnedMeshRenderer.SetBlendShapeWeight(keyIndex, vaha_nova);
    }
}
