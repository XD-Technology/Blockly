using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public List<Transform> grid = new List<Transform>();

    private List<Transform> visitedPoints = new List<Transform>();
    public GameObject WinPanel;

    public void AddVisitedPoint(Transform point)
    {
        if (!visitedPoints.Contains(point))
        {
            visitedPoints.Add(point);
            if (visitedPoints.Count >= 4)
            {
                WinPanel.SetActive(true);
            }
        }
    }
}
