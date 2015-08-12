//This class is auto-generated do not modify
namespace k
{
	public static class Scenes
	{
		public const string WIDGETS = "Widgets";
		public const string MAIN_MENU_SCENE = "mainMenuScene";
		public const string PLAY_SCENE = "playScene";

		public const int TOTAL_SCENES = 3;


		public static int nextSceneIndex()
		{
			if( UnityEngine.Application.loadedLevel + 1 == TOTAL_SCENES )
				return 0;
			return UnityEngine.Application.loadedLevel + 1;
		}
	}
}