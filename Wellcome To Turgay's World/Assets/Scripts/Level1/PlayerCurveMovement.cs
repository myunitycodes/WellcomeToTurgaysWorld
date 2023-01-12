using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PathCreation;

public partial class Player
{
    public PathCreator pathCreator;
    float distanceTravelled;
    void CurveMovement()
    {
        if (!canInput)
        {
            distanceTravelled += 15 * Time.fixedDeltaTime;

            rb.MovePosition(pathCreator.path.GetPointAtDistance(distanceTravelled));
        }
    }
}
