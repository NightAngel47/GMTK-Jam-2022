using System.Collections;
using System.Linq;
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
            RaycastHit2D[] hits = new RaycastHit2D[2];
            Vector3 charPos = transform.position;
            if (Physics2D.LinecastNonAlloc(charPos, charPos + direction, hits, _obstacleLayers) > 1)
            {
                foreach (var hit in hits)
                {
                    if (hit.transform.gameObject)
                    {
                        Debug.Log($"Hit Object: {hit.transform.gameObject.name}");
                        if (hit.transform.gameObject != gameObject)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return true;
        }
    }
}