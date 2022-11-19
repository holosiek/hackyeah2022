using System.Threading.Tasks;

namespace GameSystems
{
	public class InputSystem : AbstractGameSystem
	{
		private GameControls _gameControls;
		public GameControls GameControls => _gameControls;
		
		public override Task Initialize()
		{
			_gameControls = new GameControls();
			_gameControls.Gameplay.Enable();
			_gameControls.Gameplay2.Enable();
			
			return Task.CompletedTask;
		}
		
		public bool IsForwardPressed(PlayerType type)
        {
            if (type == PlayerType.Red)
            {
        	    return GameControls.Gameplay.Forward.IsPressed();
            }
            else
            {
        	    return GameControls.Gameplay2.Forward.IsPressed();
            }
        }
        
		public bool IsBackPressed(PlayerType type)
        {
            if (type == PlayerType.Red)
            {
        	    return GameControls.Gameplay.Back.IsPressed();
            }
            else
            {
        	    return GameControls.Gameplay2.Back.IsPressed();
            }
        }
        
		public bool IsLeftPressed(PlayerType type)
        {
            if (type == PlayerType.Red)
            {
        	    return GameControls.Gameplay.Left.IsPressed();
            }
            else
            {
        	    return GameControls.Gameplay2.Left.IsPressed();
            }
        }
        
		public bool IsRightPressed(PlayerType type)
        {
            if (type == PlayerType.Red)
            {
        	    return GameControls.Gameplay.Right.IsPressed();
            }
            else
            {
        	    return GameControls.Gameplay2.Right.IsPressed();
            }
        }
	}
}
