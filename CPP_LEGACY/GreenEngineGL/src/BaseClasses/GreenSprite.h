#pragma once

#include "PrimitiveDefinitions.h"

namespace GEGL {

	class GreenSprite
	{
	public:			 
		GreenSprite(){}
		GreenSprite(std::wstring* sFile);
		inline GreenSprite(unsigned int width, unsigned int height) { Create(width, height); }
		~GreenSprite(){}

		int pHeight = 0;
		int pWidth = 0;

	private:
		short* m_Glyphs = nullptr;
		short* m_Colors = nullptr;

		void Create(unsigned int width, unsigned int height);

	public:
		void SetGlyph(int x, int y, short c);
		short GetGlyph(int x, int y);
		void SetColor(int x, int y, short c);
		short GetColor(int x, int y);
		short SampleGlyph(float x, float y);
		short SampleColor(float x, float y);
		bool Save(std::wstring* sFile);
		bool Load(std::wstring* sFile);
	};

}