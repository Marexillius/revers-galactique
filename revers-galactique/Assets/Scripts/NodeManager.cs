using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public static NodeManager Instance { get; private set; }
    private List<Transform> nodes;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            nodes = new List<Transform>();
            foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node"))
            {
                nodes.Add(node.transform);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Transform GetRandomNode()
    {
        if (nodes.Count == 0) return null;
        return nodes[Random.Range(0, nodes.Count)];
    }
}