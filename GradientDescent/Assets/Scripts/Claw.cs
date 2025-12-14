
using Geometry;
using Math;

public class Claw : UnityEngine.MonoBehaviour
{
    private Transform Transform;
    [UnityEngine.SerializeField] private Transform target;
    [UnityEngine.SerializeField] private float radius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        double s = Functions.Clamp(3 / (target.position - Transform.position).Magnitude, 1, 3);
        transform.localScale = new Vector3(radius, radius, radius);
    }
}
