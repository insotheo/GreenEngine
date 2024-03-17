--premake5.lua

workspace "GreenEngine"
     architecture "x64"
     configurations{
          "Debug", "Release"
     }

outputdirectory = "%{cfg.buildcfg}-%{cfg.system}-%{cfg.architecture}"

project "GreenEngine"
     location "GreenEngine"
     kind "SharedLib"
     language "C++"
     targetdir("bin/"..outputdirectory.."/%{prj.name}")
     objdir("bin-inter/"..outputdirectory.."/%{prj.name}")

     files{
          "%{prj.name}/src/**.h", "%{prj.name}/src/**.cpp"
     }

     includedirs{
          "%{prj.name}/src"
     }

     filter "system:windows"
          cppdialect "C++17"
          staticruntime "On"
          systemversion "latest"
          defines{
               "GE_PLATFORM_WINDOWS", "GE_BUILD_DLL"
          }
          postbuildcommands{
               ("{COPY} %{cfg.buildtarget.relpath} ../bin/"..outputdirectory.."/DevDemoGame")
          }
          filter "configurations:Debug"
               defines "GE_CONFIGURATION_DEBUG"
               symbols "On"
          filter "configurations:Release"
               defines "GE_CONFIGURATION_RELEASE"
               optimize "On"

project "DemoGame"
     location "DemoGame"
     kind "ConsoleApp"
     language "C++"
     targetdir("bin/"..outputdirectory.."/%{prj.name}")
     objdir("bin-inter/"..outputdirectory.."/%{prj.name}")

     files{
          "%{prj.name}/src/**.h", "%{prj.name}/src/**.cpp"
     }

     includedirs{
          "GreenEngine/src"
     }

     links{
          "GreenEngine"
     }

     filter "system:windows"
          cppdialect "C++17"
          staticruntime "On"
          systemversion "latest"
          defines{
               "GE_PLATFORM_WINDOWS"
          }
          filter "configurations:Debug"
               defines "GE_CONFIGURATION_DEBUG"
               symbols "On"
          filter "configurations:Release"
               defines "GE_CONFIGURATION_RELEASE"
               optimize "On"
