#pragma once

#ifdef GE_PLATFORM_WINDOWS
extern GreenEngine::Application* GreenEngine::Create();

int main() {
	GreenEngine::Application* app = GreenEngine::Create();
	app->Run();
	delete app;
	return 0;
}
#endif