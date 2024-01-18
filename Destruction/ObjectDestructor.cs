using UnityEngine;

namespace Destruction
{
    public class ObjectDestructor : MonoBehaviour, IExplosionAffectable
    {
        public void ReactToExplosion()
        {
            Destroy(gameObject);
        }
    }
}
