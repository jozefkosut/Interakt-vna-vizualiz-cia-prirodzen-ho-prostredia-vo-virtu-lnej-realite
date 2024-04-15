using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Tetiva : MonoBehaviour
{
    [SerializeField]
    private Transform zaciatok, koniec;
    private LineRenderer tetivaViz;
    private void Awake()
    {
        tetivaViz = GetComponent<LineRenderer>();
    }
    public void VytvorTetivu(Vector3? stred)
    {
        int pocetBodov = stred.HasValue ? 3 : 2;
        Vector3[] tetivapozicia = new Vector3[pocetBodov];
        tetivapozicia[0] = zaciatok.localPosition;
        if (stred.HasValue)
        {
            tetivapozicia[1] = transform.InverseTransformPoint(stred.Value);
        }
        tetivapozicia[tetivapozicia.Length - 1] = koniec.localPosition;

        tetivaViz.positionCount = tetivapozicia.Length;
        tetivaViz.SetPositions(tetivapozicia);
    }
    private void Start()
    {
        VytvorTetivu(null);
    }
}