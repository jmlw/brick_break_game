using UnityEngine;
using System.Collections;

public interface IPaddle {

    void Launch();

    void MoveTo(Vector2 destination);
}
