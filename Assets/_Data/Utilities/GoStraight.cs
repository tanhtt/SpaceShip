using UnityEngine;

public class GoStraight : SaiMonoBehaviour
{
    [SerializeField] float speed = 2f;

    private void FixedUpdate()
    {
        this.transform.position += Vector3.up * speed * Time.fixedDeltaTime;
    }
}
