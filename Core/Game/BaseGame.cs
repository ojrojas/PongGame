namespace Pong.Core.Game;

public abstract class BaseGame
{
    private readonly IList<BaseObject> _gameObjects = [];
    private bool gameOver = false;
    protected bool _debug = false;
    public abstract void Initialize();
    public abstract void Update();
    public abstract void LoadContent();
    public abstract void Input(SDL_Event @event);
    public void Draw()
    {
        SDL_SetRenderDrawColor(_mainWindow.GetRenderer(), 10, 100, 200, 0xff);
        SDL_RenderClear(_mainWindow.GetRenderer());
        Render();
        SDL_RenderPresent(_mainWindow.GetRenderer());
    }
    public virtual void Render()
    {
        foreach (var gameObject in _gameObjects)
        {
            gameObject.Draw(_mainWindow.GetRenderer());
            if (_debug)
                gameObject.RenderBoundingBoxes(_mainWindow.GetRenderer());
        }
    }

    public virtual void AddObjects(BaseObject gameObject) => _gameObjects.Add(gameObject);

    public void SetIsGameOver(bool isGameOver) => gameOver = isGameOver;

    protected MainWindow? _mainWindow;

    public void Run()
    {
        while (!gameOver)
        {
            SDL_PollEvent(out SDL_Event @event);
            switch (@event.type)
            {
                case SDL_EVENT_WINDOW_CLOSE_REQUESTED:
                    gameOver = true;
                    break;
            }

            Input(@event);
            Draw();
            Update();
        }
    }
}