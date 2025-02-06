namespace Pong.PongNew;

public class Game : BaseGame
{
    private int Width;
    private int Height;

    private Ball ball;
    private Side side1;
    private Side side2;
    private Racket racket1;
    private Racket racket2;

    public Game(string title, (int width, int height) gameSize)
    {
        _mainWindow = new MainWindow(title, gameSize);
        Width = gameSize.width;
        Height = gameSize.height;
        Initialize();
    }

    public override void Initialize()
    {
        LoadContent();
    }

    public override void Input()
    {

    }

    public override void LoadContent()
    {
        ball = new();
        side1 = new(1);
        side2 = new(2);
        racket1 = new(1);
        racket2 = new(2);

        AddObjects(ball);
        AddObjects(side1);
        AddObjects(side2);

        AddObjects(racket1);
        AddObjects(racket2);

        ball.Position = new Vector2(Width / 2, Height / 2);
        side2.Position = new Vector2(0, Height - side2.Height);
        racket1.Position = new Vector2(0, Height / 2);
        racket2.Position = new Vector2(Width - racket2.Width, Height / 2);
    }

    public override void Update()
    {
        ball.MoveLeft();
    }
}