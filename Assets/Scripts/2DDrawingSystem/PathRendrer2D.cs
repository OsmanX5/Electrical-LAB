using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRendrer2D : PathRendrer
{
    public override void UpdateLR()
    {
        Vector3[] positions = PointsConverter.ToPositions(points);
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = Convert3Dto2DPositions.Convert3Dto2D(positions[i]);
        }
        LineRendrerOperator.PutPointsInLine(LR, positions);
    }
}
