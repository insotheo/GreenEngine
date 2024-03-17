#pragma once

#include "Core.h"

namespace GreenEngine {
	class GREEN_ENGINE_API Application {
	public:
		Application();
		virtual ~Application();

		void Run();
	};
}

