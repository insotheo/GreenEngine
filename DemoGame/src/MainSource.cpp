#include<GreenEngine.h>

class TestGame : public GreenEngine::Application {
public:
	TestGame(){

	}

	~TestGame()
	{

	}
};

GreenEngine::Application* GreenEngine::Create() {
	return new TestGame();
}