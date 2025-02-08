namespace Pong.PongNew;

public partial class Game
{
    public void InputHandler(SDL_Event @event)
    {
        InputManager.GetCommandInput(@event, command =>
        {
            LogInformation($"command sendend type: {@event.type}, event: {@event.GetType()}");
            if(command is GameInputCommand.Rack1MoveUp)
            {
                racket1.MoveUp();
                ValidateBounds(racket1);
            }

            if(command is GameInputCommand.Rack1MoveDown)
            {
                racket1.MoveDown();
                ValidateBounds(racket1);
            }

            if(command is GameInputCommand.Rack2MoveUp)
            {
                racket2.MoveUp();
                ValidateBounds(racket2);
            }

            if(command is GameInputCommand.Rack2MoveDown)
            {
                racket2.MoveDown();
                ValidateBounds(racket2);
            }
        });
    }
}