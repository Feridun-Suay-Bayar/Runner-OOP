using UnityEngine;

namespace Runner.Abstract.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }

        float MoveSpeed { get; }
        float MoveBoundary { get; }

    }
}

