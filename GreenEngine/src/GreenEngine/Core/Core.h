#pragma once

//Core.h created on 17/03/2024

#ifdef GE_PLATFORM_WINDOWS
	#ifdef GE_BUILD_DLL
			#define GREEN_ENGINE_API _declspec(dllexport)
		#else
			#define GREEN_ENGINE_API _declspec(dllimport)
	#endif
	#else
		#error GreenEngine supports only Windows platform
#endif