using System.Collections;
using UnityEngine;

namespace Movement
{
    public abstract class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _obstacleLayers;
    
        private float timeToMove = 1f;

        public bool DoneMoving { get; private set; }

        protected void MoveCharacter(Vector3 direction, int distance)
        {
            direction.Normalize();

            DoneMoving = false;

            StartCoroutine(Movement(direction, distance));
        }

        private IEnumerator Movement(Vector3 direction, int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                if (NextSpaceFree(direction))
                {
                    var charPos = transform.position;
                    Vector3 start = charPos;
                    Vector3 end = charPos + direction;

                    float step = 0;

                    do
                    {
                        step += distance / timeToMove * Time.deltaTime;
                        transform.position = Vector3.Lerp(start, end, step);
                        yield return null;
                    } while (step < 1f);
                }
                else
                {
                    break;
                }
            }
            
            DoneMoving = true;
        }

        private bool NextSpaceFree(Vector3 direction)
        {
            return !Physics2D.Linecast(transform.position, direction, _obstacleLayers);
        }
    }
}