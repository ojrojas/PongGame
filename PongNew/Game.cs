using SDL3;

namespace Pong.PongNew;

public partial class Game : BaseGame
{
    private int Width;
    private int Height;

    private Ball ball;
    private Side side1;
    private Side side2;
    private Racket racket1;
    private Racket racket2;
    private Net net;
    Dashboard dashboard;


    public Game(string title, (int width, int height) gameSize, bool debug = false)
    {
        _mainWindow = new MainWindow(title, gameSize);
        Width = gameSize.width;
        Height = gameSize.height;
        Initialize();
        _debug = debug;
    }

    public override void Initialize()
    {
        SetInputManager();
        LoadContent();
    }

    protected override void SetInputManager()
    {
        InputManager = new InputManager(new GameInputMapper());
    }

    public override void Input(SDL_Event @event)
    {
        InputHandler(@event);
    }

    public override void LoadContent()
    {
        ball = new();
        dashboard = new(Width, Height);
        side1 = new(1);
        side2 = new(2);
        racket1 = new(1);
        racket2 = new(2);
        net = new(Height, Width, 20);

        AddObjects(net);
        AddObjects(side1);
        AddObjects(side2);

        AddObjects(racket1);
        AddObjects(racket2);
        AddObjects(ball);

        ball.Position = new Vector2(Width / 2, Height / 2);
        side1.Position = Vector2.Zero;
        side2.Position = new Vector2(0, Height - side2.Height);
        racket1.Position = new Vector2(0, Height / 2);
        racket2.Position = new Vector2(Width - racket2.Width, Height / 2);
        net.Position = new(Width / 2, 0);
    }

    public override void Update()
    {
        ball.Move();
        DetectCollision();
        ValidateOutBall();
    }

    private void DetectCollision()
    {
        var ballCollisionBySideDetector = new CollisionDetector<Side, Ball>([side1, side2]);
        var ballCollisionByRacketDetector = new CollisionDetector<Racket, Ball>([racket1, racket2]);
        var ballOutDashboardDetector = new CollisionDetector<Dashboard,Ball>([dashboard]);

        ballCollisionBySideDetector.DetectCollisions(ball, (side, ball) =>
        {
            var hitSideEvent = new BaseObjectEvent.ObjectHitBy(side.Name);
            ball.OnNotify(hitSideEvent);
        });

        ballCollisionByRacketDetector.DetectCollisions(ball, (racket, ball) =>
        {
            var hitRacketEvent = new BaseObjectEvent.ObjectHitBy(racket.Name);
            ball.OnNotify(hitRacketEvent);
        });

        ballOutDashboardDetector.DetectCollisions(ball, (dash, ball) => {
            var hitDashboardEvent = new BaseObjectEvent.ObjectHitBy(dash.Name);
            ball.OnNotify(hitDashboardEvent);
        });
    }

    private void ValidateBounds(Racket racket)
    {
        if (racket.Position.Y <= 0)
            racket.Position = new Vector2(racket.Position.X, 1);
        if (racket.Position.Y >= (Height - racket.Height))
            racket.Position = new Vector2(racket.Position.X, (Height - racket.Height) - 1);
    }

    private void ValidateOutBall()
    {
        if (ball._ballisOut)
        {
            ball.Position = new Vector2(Width / 2, Height / 2);
            ball.RestarBall();
        }
    }
}