using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerDetector : MonoBehaviour
{

    public GameObject[] currentRow;
    public GameObject[] answerKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Evaluate();
        }
    }

    private void Evaluate()
    {
        Material[] answerMats = new Material[answerKey.Length];
        for (int i = 0; i < answerKey.Length; i++)
        {
            Material temp = answerKey[i].GetComponent<MeshRenderer>().material;
            answerMats[i] = temp;
        }

        Material[] currentRowMats = new Material[currentRow.Length];
        for (int i = 0; i <currentRow.Length; i++)
        {
            Material temp = currentRow[i].GetComponent<MeshRenderer>().material;
            currentRowMats[i] = temp;
        }

        int xx = 13;
    }
}
