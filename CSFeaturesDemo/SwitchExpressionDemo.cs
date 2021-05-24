using System;
namespace CSFeaturesDemo
{
    public record Circle(int Radius);
    public record Rectangle(int Length, int Width);
    public record Triangle(int Side1, int Side2, int Side3);

    public static class SwitchExpressionDemo
    {
        public static string DisplayShapeInfo(object shape) =>
         shape switch
            {
                Rectangle r => r switch
                {
                    _ when r.Length == r.Width => $"Square! {r}",
                    _ => $"Rectangle! {r}"
                },
                Circle {  Radius: 1 } c => $"Small Circle! {c}",
                Circle c => $"Circle {c}",
                Triangle t => $"Triangle {t}",
                _ => $"Unknown Shape {shape}"
            };
    }
}
