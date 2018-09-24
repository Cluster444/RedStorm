namespace RedStorm
{
    public static class Mathf
    {
        public const float PI = 3.14159f;
        public const float TWOPI = PI * 2;
        public const float HALFPI = PI / 2;

        public static float ClampRadiansTwoPI(float angle)
        {
            angle = angle % TWOPI;
            if (angle < 0) angle += TWOPI;
            return angle;
        }
    }
}
