using Microsoft.Xna.Framework;

namespace BinaryCartographicsEngine.BCEngine.Math
{
    public class Transform
    {
        /// <summary>
        /// Parent Child transform stuff
        /// </summary>
        public Transform WorldTransform
        {
            get
            {
                return IsChild ?
                Transform.Compose(Parent, this) :
                this;
            }
        }
        /// <summary>
        /// Positions
        /// </summary>
        public Vector2 Position = Vector2.Zero;
        public Vector2 WorldPosition
        {
            get { return WorldTransform.Position; }
        }
        /// <summary>
        /// Scales
        /// </summary>
        public Vector2 Scale = Vector2.One;
        public Vector2 WorldScale
        {
            get { return WorldTransform.Scale; }
        }
        /// <summary>
        /// Rotations
        /// </summary>
        public float Rotation = 0;
        public float WorldRotation
        {
            get { return WorldTransform.Rotation; }
        }
        public float RotationDegrees
        {
            set { Rotation = MathHelper.ToRadians(value); }
        }
        public float RotationRadians
        {
            set { Rotation = value; }
        }
        #region Base properties
        public bool IsChild { get; }
        public Transform Parent { get; }
        public bool IsEnabled { get; }
        #endregion

        public Transform() { }
        public Transform(Transform parent)
        {
            IsChild = true;
            Parent = parent;
        }

        private static readonly Transform identity = new Transform();
        public static Transform Identity { get { return identity; } }

        public static Transform Compose(Transform parent, Transform child)
        {
            Transform result = new Transform();
            result.Position = parent.Position + Vector2.Transform(child.Position * parent.Scale, Matrix.CreateRotationZ(parent.Rotation));
            result.Rotation = parent.Rotation + child.Rotation;
            result.Scale = parent.Scale * child.Scale;
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
