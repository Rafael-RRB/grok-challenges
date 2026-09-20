using JokenpoTerminal.Enums;
using JokenpoTerminal.Render;
using JokenpoTerminal.Structs;
using JokenpoTerminal.Game;
using JokenpoTerminal.Helpers;

namespace JokenpoTerminal.Screens
{
    public class IntroScreen : Screen
    {
        private Layer protagonistLayer = null!;
        private Layer sparkleLayer = null!;
        private Layer triangleLayer = null!;
        private Layer squareLayer = null!;
        private Layer circleLayer = null!;
        private Layer messageLayer = null!;
        private int leftOffset = 0;
        private double sparkleTimer = 0;
        private double triangleTimer = 0;
        private double squareTimer = 0;
        private double circleTimer = 0;
        private double slideTimer = 0;
        private double introTimer = 0;
        private int triangleDirection = -1;
        private int squareDirection = -1;
        private int circleDirection = 1;
        private bool introFinished = false;

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
            messageLayer = new Layer
            {
                Content = DialogBox.Create("Press any key to start..."),
                Position = new Position(0, 0),
                Color = ConsoleColor.White,
                HorizontalAlign = XAlign.Center,
                VerticalAlign = YAlign.Bottom,
                IsVisible = false
            };
        }
        public override void Update(Renderer renderer, Assets assets, double deltaTime)
        {
            #region Add time to all basic timers
            sparkleTimer += deltaTime;
            triangleTimer += deltaTime;
            squareTimer += deltaTime;
            circleTimer += deltaTime;
            slideTimer += deltaTime;
            #endregion

            #region Animate all basic layers
            if (sparkleTimer >= 1.0)
            {
                sparkleTimer -= 1.0;
                sparkleLayer.IsVisible = sparkleLayer.IsVisible ? false : true;
            }

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
            #endregion

            #region Slide frames into place
            if (leftOffset > 0)
            {
                if (slideTimer >= 1.0 / 20.0)
                {
                    slideTimer -= 1.0 / 20.0;
                    leftOffset = Math.Max(0, leftOffset - 1); // Prevents negative values and weird rounding errors
                }
            }
            #endregion

            #region Menu logic
            else if (!introFinished && leftOffset == 0)
            {
                introFinished = true;
            }

            if (introFinished)
            {
                introTimer += deltaTime;
            }

            if (introTimer >= 1)
            {
                messageLayer.IsVisible = !messageLayer.IsVisible;

                if (messageLayer.IsVisible)
                {
                    introTimer -= 1;
                }
                else
                {
                    introTimer -= 0.5;
                }
            }
            #endregion

            #region Apply offset to all basic layers
            protagonistLayer.Position.X = leftOffset;
            sparkleLayer.Position.X = leftOffset;
            triangleLayer.Position.X = leftOffset;
            squareLayer.Position.X = leftOffset;
            circleLayer.Position.X = leftOffset;
            #endregion
        }

        public override void Draw(Renderer renderer, Assets assets)
        {
            renderer.AddLayer(sparkleLayer);
            renderer.AddLayer(triangleLayer);
            renderer.AddLayer(squareLayer);
            renderer.AddLayer(circleLayer);
            renderer.AddLayer(protagonistLayer);
            renderer.AddLayer(messageLayer);
        }
        public override void HandleInput(ConsoleKeyInfo key)
        {
            // TBA
        }

        public override void Exit(Renderer renderer, Assets assets)
        {
            sparkleTimer = 0;
            triangleTimer = 0;
            squareTimer = 0;
            circleTimer = 0;
            slideTimer = 0;
            introTimer = 0;
            triangleDirection = -1;
            squareDirection = -1;
            circleDirection = 1;
            introFinished = false;
        }

        public IntroScreen() {}
    }
}