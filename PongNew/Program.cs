(int x, int y) = (70, 30);

bool gameOver = false;
IShovel shovel2 = new Shovel { PositionX = 3, PositionY = 16, KeyUp = ConsoleKey.UpArrow, KeyDown = ConsoleKey.DownArrow };
IShovel shovel1 = new Shovel { PositionX = x - 3, PositionY = 16, KeyUp = ConsoleKey.O, KeyDown = ConsoleKey.L };
IShovel shovel3 = new Shovel { PositionX = 15, PositionY = 16, KeyUp = ConsoleKey.E, KeyDown = ConsoleKey.D };

var mainWindow = new MainWindow("Pong", (1024, 768));

while (!gameOver)
{
    SDL_PollEvent(out SDL_Event @event);
    switch (@event.type)
    {
        case SDL_EVENT_WINDOW_CLOSE_REQUESTED:
            gameOver = true;
            break;
    }


    SDL_SetRenderDrawColor(mainWindow.GetRenderer(), 1, 0, 0, 0xff);
    SDL_RenderClear(mainWindow.GetRenderer());
    SDL_RenderPresent(mainWindow.GetRenderer());
    SDL_GL_SwapWindow(mainWindow.GetWindow());
}