using LAB02_TurkmiteLab;
using OpenCvSharp;

namespace Tests
{
    public class Basics
    {
        [Fact]
        public void Instantiation()
        {
            var t = new Turkmite(null);
        }

        [Fact]
        public void TestTurn()
        {
            var t = new TestedTurkmite(new DefaultImage());
            Assert.Equal(0, t.Direction);
            t.ApplyRulesForTesting(t.Black);
            Assert.Equal(1, t.Direction);
        }

        class TestedTurkmite : Turkmite
        {
            public TestedTurkmite(IImage img) : base(img)
            {
            }

            public int X { get => this.x; }
            public int Y { get => this.y; }
            public int Direction { get => this.direction; }

            public void ApplyRulesForTesting(Vec3b currentColor)
            {
                this.ApplyRules(currentColor);
            }
        }
    }
}