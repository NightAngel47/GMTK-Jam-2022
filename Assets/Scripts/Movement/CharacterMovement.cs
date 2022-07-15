using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    protected float unitsPerSec = 1f;

    /// <summary> Moves a character based on the given units. </summary>
    /// <param name="newRelativePos"> How far to move this character in each direction. </param>
    protected void Move(Vector3 unitsToMove)
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position + unitsToMove;

        float step = 0;

        do
        {
            step += unitsPerSec * Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, step);
        } while (step < 1f);
    }
}