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
     