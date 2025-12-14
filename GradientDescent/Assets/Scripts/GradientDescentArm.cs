using Geometry;

namespace Math
{
    public class GradientDescentArm : UnityEngine.MonoBehaviour
    {
        [UnityEngine.SerializeField] RotatoryJoint joint;
        [UnityEngine.SerializeField] Transform target;

        void Start()
        {
            joint = this.GetComponent<RotatoryJoint>();
        }

        void Update()
        {
            GradientDescent.Update(joint, target);
        }
    }
}
