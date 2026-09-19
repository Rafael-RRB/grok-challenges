using JokenpoTerminal.Enums;
using JokenpoTerminal.Render;
using JokenpoTerminal.Structs;
using JokenpoTerminal.Game;

namespace JokenpoTerminal.Screens
{
    public class IntroScreen : Screen
    {
        private Layer protagonistLayer = null!;
        private Layer sparkleLayer = null!;
        private Layer triangleLayer = null!;
        private Layer squareLayer = null!;
        private Layer circleLayer = null!;
        private int leftOffset = 0;
        private double sparkleTimer = 0;
        private double triangleTimer = 0;
        private double squareTimer = 0;
        private double circleTimer = 0;
        private double slideTimer = 0;
        private int triangleDirection = -1;
        private int squareDirection = -1;
        private int circleDirection = 1;
        public override void Enter(Renderer renderer, Assets assets)
        {
            leftOffset = renderer.LogicalWidth;

            protagonistLayer = new Layer
            {
                Content = assets.introBGProtagonist,
                Position = new Position(0, 0),
                Color = ConsoleColor.Cyan,
                HorizontalAlign = XAlign.Center,
                VerticalAlign = YAlign.Middle,
            };
            sparkleLayer = new Layer
            {
                Content = assets.introBGStars,
                Position = new Position(0, 0),
                Color = ConsoleColor.Cyan,
                HorizontalAlign = XAlign.Center,
                VerticalAlign = YAlign.Middle,
            };
            triangleLayer = new Layer
            {
                Content = assets.introBGTriangle,
                Position = new Position(0, 0),
                Color = ConsoleColor.Red,
                HorizontalAlign = XAlign.Center,
                VerticalAlign = YAlign.Middle,
            };
            squareLayer = new Layer
            {
                Content = assets.introBGSquare,
                Position = new Position(0, 0),
                Color = ConsoleColor.Green,
                HorizontalAlign = XAlign.Center,
                VerticalAlign = YAlign.Middle,
            };
            circleLayer = new Layer
            {
                Content = assets.introBGCircle,
                Position = new Position(0, 0),
                Color = ConsoleColor.Blue,
                HorizontalAlign = XAlign.Center,
                VerticalAlign = YAlign.Middle,
            };
        }
        public override void Update(Renderer renderer, Assets assets, double deltaTime)
        {
            // Is there a less repeat-y way of doing this?
            sparkleTimer += deltaTime;
            triangleTimer += deltaTime;
            squareTimer += deltaTime;
            circleTimer += deltaTime;
            slideTimer += deltaTime;

            if (sparkleTimer >= 1.0)
            {
                sparkleTimer -= 1.0;
                sparkleLayer.IsVisible = sparkleLayer.IsVisible ? false : true;
            }

            // Triangle Animation
            if (triangleTimer >= 0.5)
            {
                triangleTimer -= 0.5;
                triangleLayer.Position.Y += triangleDirection;
                if (triangleLayer.Position.Y >= 2)
                {
                    triangleDirection = -1;
                }
                else if (triangleLayer.Position.Y <= 0)
                {
                    triangleDirection = 1;
                }
            }

            // Square Animation
            if (squareTimer >= 0.5)
            {
                squareTimer -= 0.5;
                squareLayer.Position.Y += squareDirection;
                if (squareLayer.Position.Y >= 1)
                {
                    squareDirection = -1;
                }
                else if (squareLayer.Position.Y <= -1)
                {
                    squareDirection = 1;
                }
            }

            // Circle Animation
            if (circleTimer >= 0.5)
            {
                circleTimer -= 0.5;
                circleLayer.Position.Y += circleDirection;
                if (circleLayer.Position.Y >= 1)
                {
                    circleDirection = -1;
                }
                else if (circleLayer.Position.Y <= -1)
                {
                    circleDirection = 1;
                }
            }

            if (leftOffset > 0)
            {
                if (slideTimer >= 1.0 / 20.0)
                {
                    slideTimer -= 1.0 / 20.0;
                    leftOffset = leftOffset - 1;
                }
            }

            foreach (Layer layer in new Layer[5] { protagonistLayer, sparkleLayer, triangleLayer, squareLayer, circleLayer })
            {
                layer.Position.X = leftOffset;
            }
        }

        public override void Draw(Renderer renderer, Assets assets)
        {
            renderer.AddLayer(sparkleLayer);
            renderer.AddLayer(triangleLayer);
            renderer.AddLayer(squareLayer);
            renderer.AddLayer(circleLayer);
            renderer.AddLayer(protagonistLayer);
        }
        public override void HandleInput(ConsoleKeyInfo key)
        {
            // TBA
        }

        public override void Exit(Renderer renderer, Assets assets)
        {
            foreach (Layer layer in new Layer[5] { protagonistLayer, sparkleLayer, triangleLayer, squareLayer, circleLayer})
            {
                layer.Position = Position.Zero;
            }   
        }

        public IntroScreen() {}
    }
}