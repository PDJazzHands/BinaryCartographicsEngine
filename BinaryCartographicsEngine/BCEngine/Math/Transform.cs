using Microsoft.Xna.Framework;

namespace BinaryCartographicsEngine.BCEngine.Math
{
    public class Transform
    {
        public Vector2 Position = Vector2.Zero;
        public Vector2 Scale = Vector2.One;
        public float Rotation = 0;

        private static readonly Transform identity = new Transform();
        public static Transform Identity { get { return identity; } }

        public static Transform Compose(Transform a, Transform b)
        {
            Transform result = new Transform();
            Vector2 transformedPosition = a.TransformVector(b.Position);
            result.Position = transformedPosition;
            result.Rotation = a.Rotation + b.Rotation;
            result.Scale = a.Scale * b.Scale;
            return result;
        }

        public static void Lerp(ref Transform from, ref Transform to, float amount, ref Transform result)
        {
            result.Position = Vector2.Lerp(from.Position, to.Position, amount);
            result.Scale = Vector2.Lerp(from.Scale, to.Scale, amount);
            result.Rotation = MathHelper.Lerp(from.Rotation, to.Rotation, amount);
        }

        public Vector2 TransformVector(Vector2 point)
        {
            Vector2 result = Vector2.Transform(point, Matrix.CreateRotationZ(Rotation));
            result *= Scale;
            result += Position;
            return result;
        }
    }
}
