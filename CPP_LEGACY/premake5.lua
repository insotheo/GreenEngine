--premake5.lua

workspace "GreenEngine"
     architecture "x64"
     configurations{
          "Debug", "Release"
     }

outputdirectory = "%{cfg.buildcfg}-%{cfg.system}-%{cfg.architecture}"

project "GreenEngineGL"
     kind "SharedLib"
     language "C++"
     location "GreenEngineGL"
     targetdir("bin/"..outputdirectory.."/%{prj.name}")
     objdir("bin-inter/"..outputdirectory.."/%{prj.name}")
     files{
          "%{prj.name}/src/**.cpp",
          "%{prj.name}/src/**.h"
     }
     includedirs{
          "%{prj.name}/src"
     }


project "DemoGame"
     kind "ConsoleApp"
     language "C++"
     location "DemoGame"
     targetdir("bin/"..outputdirectory.."/%{prj.name}")
     objdir("bin-inter/"..outputdirectory.."/%{prj.name}")
     files{
          "%{prj.name}/src/**.cpp",
          "%{prj.name}/src/**.h"
     }
     includedirs{
          "GreenEngineGL/src"
     }