namespace Pong.Core.Window;

public sealed unsafe class MainWindow
{
    private readonly SDL_Window _window;
    private readonly SDL_Renderer _renderer;

    public MainWindow(string title, (int w, int h) windowSize)
    {
        GetVersionSDL();
        Initialize();
        _window = SDL_CreateWindow(title, windowSize.w, windowSize.h, SDL_WindowFlags.Resizable);
        _renderer = SDL_CreateRenderer(_window,"");
        if (_window.IsNull && _renderer.IsNull)
        {
            LogError("Error to create window or renderer ", SDL_GetError());            
            throw new InvalidOperationException("Failed to create window or renderer");
        }

        SDL_SetWindowPosition(_window, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED);
        SDL_GLContext gl_context = SDL_GL_CreateContext(_window);
        SDL_GL_MakeCurrent(_window, gl_context);
        SDL_GL_SetSwapInterval(1);
        SDL_ShowWindow(_window);

        var id = SDL_GetWindowID(_window);
        var driversAudio = SDL_GetNumAudioDrivers();
        for (int i = 0; i < driversAudio; i++)
            LogInformation($"Driver name: {SDL_GetAudioDriver(i)!}");

        ReadOnlySpan<SDL_JoystickID> joystics = SDL_GetJoysticks();
        foreach (var joystic in joystics)
        {
            var gamePad = SDL_OpenGamepad(joystic);
            LogInformation($"Game pad: {SDL_GetGamepadName(gamePad)}");
        }
    }

    ~MainWindow(){
        SDL_DestroyRenderer(_renderer);
        SDL_DestroyWindow(_window);
        SDL_Quit();
    }

    private static void GetVersionSDL()
    {
        var version = SDL_GetVersion();
        string platform = SDL_GetPlatform()!;
        LogInformation($"version sdl: {SDL_VERSIONNUM_MAJOR(version)}.{SDL_VERSIONNUM_MINOR(version)}.{SDL_VERSIONNUM_MICRO(version)}");
        LogInformation($"Platform: {platform}");
    }

    private static void Initialize()
    {
#if DEBUG
        SDL_SetLogPriorities(SDL_LogPriority.Debug);
#endif

        SDL_GL_SetAttribute(SDL_GLAttr.ContextMajorVersion, 3);
        SDL_GL_SetAttribute(SDL_GLAttr.ContextMinorVersion, 3);
        SDL_GL_SetAttribute(SDL_GLAttr.ContextProfileMask, SDL_GLProfile.Core);
#if __APPLE__
        SDL_GL_SetAttribute(SDL_GL_CONTEXT_FLAGS, SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG); 
#endif
        SDL_GL_SetAttribute(SDL_GLAttr.Doublebuffer, true);
        SDL_GL_SetAttribute(SDL_GLAttr.DepthSize, 24);
        SDL_GL_SetAttribute(SDL_GLAttr.StencilSize, 8);

        SDL_SetHint(SDL_HINT_IME_IMPLEMENTED_UI, true);

        if (SDL_InitSubSystem(SDL_InitFlags.Video | SDL_InitFlags.Gamepad | SDL_InitFlags.Joystick) != true)
            throw new InvalidOperationException("Failed to initialize libraries sdl3");
    }

    public SDL_Window GetWindow() => _window;
    public SDL_Renderer GetRenderer() => _renderer;

}