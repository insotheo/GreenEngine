using System.Collections.Generic;

namespace GreenEngineAPI.Core
{
    public class SceneManager
    {
        private List<Scene2D> Scenes;
        private Scene2D CurrentScene;

        public SceneManager(Scene2D firstScene)
        {
            Scenes = new List<Scene2D>();
            Scenes.Add(firstScene);
            LoadScene(0);
        }

        public void AddScene(Scene2D scene) { Scenes.Add(scene); }
        public void RemoveScene(Scene2D scene) { Scenes.Remove(scene); }
        public Scene2D GetCurrentScene() { return CurrentScene; }

        public void LoadScene(int index)
        {
            CurrentScene = Scenes[index];
            CurrentScene.OnLoad();
        }

        public void InsertScene(int index, Scene2D scene)
        {
            Scenes.Insert(index, scene);
        }

        public int GetIndexOfCurrentScene()
        {
            return Scenes.IndexOf(CurrentScene);
        }

    }
}
