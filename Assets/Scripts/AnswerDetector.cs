using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnswerDetector : MonoBehaviour
{

    public GameObject[] currentRow;
    public GameObject[] answerKey;
    [SerializeField] GameObject[] pins;
    [SerializeField] GameObject hintGrid;

    GameObject[] pinSlots;
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

        Report(answerMats, currentRowMats);
    }

    void Report(Material[] answerMats, Material[] currentMats)
    {
        int[] answerValues = new int[currentMats.Length];
        List<Material> compMats = answerMats.ToList();
        List<Color> colorAnswers = new List<Color>();

        foreach (var item in compMats)
        {
            colorAnswers.Add(item.color);
        }

        for (int i = 0; i < currentMats.Length; i++)
        {
            if (currentMats[i].color == answerMats[i].color)
            {
                answerValues[i] = 1;
                InstantiatePin(0, hintGrid.transform.GetChild(i).transform);
            }
            else if (colorAnswers.Contains(currentMats[i].color))
            {
                answerValues[i] = 0;
                InstantiatePin(1, hintGrid.transform.GetChild(i).transform);
            }
            else
            {
                answerValues[i] = -1;
            }
            Debug.Log(answerValues[i]);
        }
    }

    void InstantiatePin(int index, Transform transform)
    {
        GameObject pin = Instantiate(pins[index]);
        pin.transform.position = transform.position;
    }
}

