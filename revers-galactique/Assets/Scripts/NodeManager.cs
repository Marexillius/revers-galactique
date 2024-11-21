using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public static NodeManager Instance { get; private set; }
    private List<Transform> nodes;

    private GameObject noder; //doesnt really work, we should find a way to put this into the enemyAI script
    private List<Transform> noders;

    private void Awake()
    {
        if (Instance == null)
        {
            /*Instance = this;
            noders = new List<Transform>();

            for (int i = 0; i < noder.transform.childCount; i++)
            {
                noders.Add(noder.transform.GetChild(i));
            }
                    I think that was it?
             */
        }
        else
        {
            Destroy(gameObject);
        }

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