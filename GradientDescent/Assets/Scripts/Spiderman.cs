using Geometry;
using Math;

public class Spiderman : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] private Transform Transform;
    [UnityEngine.SerializeField, UnityEngine.Range(0, 1)] private double speed;

    [UnityEngine.SerializeField, UnityEngine.Range(1, 30)] private float minRadius; 
    [UnityEngine.SerializeField, UnityEngine.Range(1, 30)] private float maxRadius;

    [UnityEngine.SerializeField, UnityEngine.Range(1, 10)] private float radius;

    [UnityEngine.SerializeField] private double jumpCooldown;
    [UnityEngine.SerializeField] private double curJumpCooldown = 0;
    [UnityEngine.SerializeField] private UnityEngine.AnimationCurve jumpCurve;
    [UnityEngine.SerializeField, UnityEngine.Range(0, 10)] private float jumpSpeed;
    private bool jumping = false;

    private Vector3 target;
    private readonly float tolerance = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform = this.GetComponent<Transform>();
        target = Transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        curJumpCooldown += UnityEngine.Time.deltaTime;
        if (curJumpCooldown > jumpCooldown && !jumping)
            StartCoroutine(Jump());

        Transform.position += speed * (target - Transform.position).Normalized;

        if ((target - Transform.position).SqrMagnitude > tolerance) return;

        int iterations = 0;
        do
        {
            target = new Vector3(
                UnityEngine.Random.Range(-maxRadius, maxRadius),
                1,
                UnityEngine.Random.Range(-maxRadius, maxRadius)
                );
            iterations++;
            if (iterations > 100)
            {
                target = new Vector3(
                    (minRadius + maxRadius) / 2,
                    1,
                    (minRadius + maxRadius) / 2
                    );
                break;
            }
        } while (Functions.Sqrt(target.x * target.x + target.z * target.z) < minRadius ||
        Functions.Sqrt(target.x * target.x + target.z * target.z) > maxRadius ||
        (target - Transform.position).Magnitude > radius);
    }

    private System.Collections.IEnumerator Jump()
    {
        jumping = true;
        float t = 0;
        while (t < 1)
        {
            t += UnityEngine.Time.deltaTime * jumpSpeed;
            Vector3 newPos = Transform.position;
            newPos.y = jumpCurve.Evaluate(t);
            Transform.position = newPos;
            yield return new UnityEngine.WaitForEndOfFrame();
        }
        curJumpCooldown = 0;
        jumping = false;
    }
}
