using System.Collections;
using UnityEngine;

namespace Movement
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _obstacleLayers;
    
        private float unitsPerSec = 1f;

        protected void MoveCharacter(Vector3 direction, int distance)
        {
            direction.Normalize();
        
            for (int i = 0; i < distance; i++)
            {
                if (NextSpaceFree(direction))
                {
                    StartCoroutine(Movement(direction));
                }
                else
                {
                    return;
                }
            }
        }

        private IEnumerator Movement(Vector3 direction)
        {
            var charPos = transform.position;
            Vector3 start = charPos;
            Vector3 end = charPos + direction;

            float step = 0;

            do
            {
                step += unitsPerSec * Time.deltaTime;
                transform.position = Vector3.Lerp(start, end, step);
                yield return null;
            } while (step < 1f);
        }

        private bool NextSpaceFree(Vector3 direction)
        {
            return !Physics2D.Linecast(transform.position, direction, _obstacleLayers);
        }
    }
}