using System.Collections.Generic;
using UnityEngine;
public static class BlockConfigurations
{
    public static List<(List<Vector3> Positions, List<Vector3> Scales)> Configurations = new List<(List<Vector3> Positions, List<Vector3> Scales)>
    {
        (new List<Vector3> { Vector3.zero }, new List<Vector3> { new Vector3(1, 1, 1) }),

        (
            new List<Vector3>
            {
                new Vector3(-0.25f, 0f, 0.25f),
                new Vector3(-0.25f, 0f, -0.25f),
                new Vector3(0.25f, 0f, 0.25f),
                new Vector3(0.25f, 0f, -0.25f),
            },
            new List<Vector3>
            {
                new Vector3(0.5f, 1f, 0.5f),
                new Vector3(0.5f, 1f, 0.5f),
                new Vector3(0.5f, 1f, 0.5f),
                new Vector3(0.5f, 1f, 0.5f)
            }
        ),

        (
            new List<Vector3>
            {
                new Vector3(-0.25f, 0f, 0.25f),
                new Vector3(-0.25f, 0f, -0.25f),
                new Vector3(0.25f, 0, 0)
            },
            new List<Vector3>
            {
                new Vector3(0.5f, 1f, 0.5f),
                new Vector3(0.5f, 1f, 0.5f),
                new Vector3(0.5f, 1, 1)
            }
        ),

        (
            new List<Vector3>
            {
                new Vector3(0.25f, 0f, 0.25f),
                new Vector3(0.25f, 0f, -0.25f),
                new Vector3(-0.25f, 0, 0)
            },
            new List<Vector3>
            {
                new Vector3(0.5f, 1f, 0.5f),
                new Vector3(0.5f, 1f, 0.5f),
                new Vector3(0.5f, 1, 1)
            }
        ),

        (
            new List<Vector3>
            {
                new Vector3(0f, 0f, -0.25f),
                new Vector3(-0.25f, 0f, 0.25f),
                new Vector3(0.25f, 0f, 0.25f)
            },
            new List<Vector3>
            {
                new Vector3(1f, 1f, 0.5f),
                new Vector3(0.5f, 1f, 0.5f),
                new Vector3(0.5f, 1f, 0.5f)
            }
        ),

        (
            new List<Vector3>
            {
                new Vector3(0f, 0f, 0.25f),
                new Vector3(-0.25f, 0f, -0.25f),
                new Vector3(0.25f, 0f, -0.25f)
            },
            new List<Vector3>
            {
                new Vector3(1f, 1f, 0.5f),
                new Vector3(0.5f, 1f, 0.5f),
                new Vector3(0.5f, 1f, 0.5f)
            }
        )
    };
}
