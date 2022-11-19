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
	}
}
