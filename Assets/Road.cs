using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Vector3 instPos;
    public Vector3 startPos;
    private float resetThreshold;

    void Start()
    {
        // Calculate the exact reset point
        resetThreshold = instPos.z - 1;
    }

    void Update()
    {
        float moveSpeed = 0.01f * CarMove.speed * Time.timeScale * PlayerPrefs.GetFloat("quality", 2.5f);
        moveSpeed = Mathf.Round(moveSpeed * 100f) / 100f;

        // Check BEFORE moving
        if (transform.position.z <= resetThreshold)
        {
            cleanAllChilds();
            transform.position += new Vector3(0, 0, 12);
        }

        // Move after checking
        transform.position += new Vector3(0, 0, -moveSpeed);
    }

    void cleanAllChilds()
    {
        for (int i = 3; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
