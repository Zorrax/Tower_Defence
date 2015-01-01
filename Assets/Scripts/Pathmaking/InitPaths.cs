using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitPaths : MonoBehaviour
{
    public GameObject cube, basicTower;
    public List<Path> paths = new List<Path>();
    public Transform startPos;
    public int seed;

    private GameObject placeholder;
    private Vector3 direction, calculatedPoint;
    private float angle, bezierX, bezierZ, T;
    private List<JunctionTier> junctionTier = new List<JunctionTier>();
    private int indexJunctionTier = 0, indexJunction = 0, indexPath = 0;
    private bool canPlace = true;
    private List<Vector3> junctionsInPath = new List<Vector3>();

    void Start()
    {
        Random.seed = seed;
        junctionTier.Add(new JunctionTier());
        junctionTier[indexJunctionTier].junction.Add(new Junction());
        junctionTier[indexJunctionTier].junction[0].point = startPos.position;

        for (int quantityJunctionTier = 0; quantityJunctionTier < 5; quantityJunctionTier++)
        {
            junctionTier.Add(new JunctionTier());
            indexJunctionTier++;
            indexJunction = 0;
            foreach (Junction previousJunction in junctionTier[indexJunctionTier - 1].junction)
            {
                for (int quantityJunction = 0; quantityJunction < 3 + indexJunctionTier; quantityJunction++)
                {
                    angle = Random.Range(135f, 315f);
                    direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), 0, Mathf.Sin(Mathf.Deg2Rad * angle));
                    calculatedPoint = previousJunction.point + direction * Random.Range(5f, 7f);
                    canPlace = true;
                    CheckPoint();
                }

                foreach (Junction currentJunction in junctionTier[indexJunctionTier].junction)
                {
                    if (Vector3.Distance(previousJunction.point, currentJunction.point) < 7)
                    {
                        CreatePath(previousJunction, currentJunction);
                    }
                    if (!previousJunction.hasTower && previousJunction.bezierPoint.x != 0)
                    {
                        Vector3 spawnpoint = new Vector3(previousJunction.bezierPoint.x, previousJunction.bezierPoint.y + 0.5f, previousJunction.bezierPoint.z);
                        Instantiate(basicTower, spawnpoint, Quaternion.identity);
                        previousJunction.hasTower = true;
                    }
                }
            }
        }
    }

    private void CreatePath(Junction previousJunction, Junction currentJunction)
    {
        paths.Add(new Path());
        junctionsInPath.Clear();
        junctionsInPath.Add(previousJunction.point);
        if (indexJunctionTier > 1)
        {
            junctionsInPath.Add(previousJunction.bezierPoint);
        }
        for (int k = 0; k < 2; k++)
        {
            junctionsInPath.Add(new Vector3(previousJunction.point.x - Random.Range(0 + (k * 0.5f + 1), 2 * (k * 0.5f + 1)), 0.5f, previousJunction.point.z - Random.Range(0 + (k * 0.5f + 1), 2 * (k * 0.5f + 1))));
        }
        junctionsInPath.Add(currentJunction.point);
        float n = junctionsInPath.Count - 1;
        Bezier(n);
        int end = paths[indexPath].points.Count;
        if (currentJunction.bezierPoint.x == 0)
        {
            currentJunction.bezierPoint = (paths[indexPath].points[end - 1] - paths[indexPath].points[end - 2]) * 5 + paths[indexPath].points[end - 1];
        }
        else
        {
            currentJunction.bezierPoint = (currentJunction.bezierPoint / 2) + ((paths[indexPath].points[end - 1] - paths[indexPath].points[end - 2]) * 5 + paths[indexPath].points[end - 1]) / 2;
        }
        paths[indexPath].junction = currentJunction;
        foreach (Path m in paths)
        {
            if (m.junction == previousJunction)
            {
                m.connectedTo.Add(indexPath);
            }
        }
        indexPath++;
    }

    private void Bezier(float n)
    {
        for (int u = 0; u < 20; u++)
        {
            T = u / 20f;
            bezierX = 0;
            bezierZ = 0;
            for (int i = 0; i < n + 1; i++)
            {
                bezierX = bezierX + (Factorial(n) / (Factorial(i) * Factorial(n - i))) * Mathf.Pow((1 - T), (n - i)) * Mathf.Pow(T, i) * junctionsInPath[i].x;
                bezierZ = bezierZ + (Factorial(n) / (Factorial(i) * Factorial(n - i))) * Mathf.Pow((1 - T), (n - i)) * Mathf.Pow(T, i) * junctionsInPath[i].z;
            }
            paths[indexPath].points.Add(new Vector3(bezierX, 0.5f, bezierZ));
            //Instantiate(cube, paths[indexPath].points[u], Quaternion.identity);
        }
    }

    private void CheckPoint()
    {
        if (calculatedPoint.x > 8 || calculatedPoint.z > 8)
        { // farlig men skulle holde dem inde
            canPlace = false;
        }
        foreach (Junction previousJunctions in junctionTier[indexJunctionTier - 1].junction)
        {
            if (Vector3.Distance(calculatedPoint, previousJunctions.point) < 5)
            {
                canPlace = false;
            }
        }
        foreach (Junction currentJunctions in junctionTier[indexJunctionTier].junction)
        {
            if (Vector3.Distance(calculatedPoint, currentJunctions.point) < 3)
            {
                canPlace = false;
            }
        }
        if (canPlace)
        {
            junctionTier[indexJunctionTier].junction.Add(new Junction());
            junctionTier[indexJunctionTier].junction[indexJunction].point = calculatedPoint;
           // Instantiate(cube, calculatedPoint, Quaternion.identity);
            indexJunction++;
        }
    }

    float Factorial(float number)
    {
        if (number == 0)
        {
            return 1;
        }
        return number * Factorial(number - 1);
    }



}
