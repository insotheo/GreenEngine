#include "GreenSprite.h"


namespace GEGL {
	
	GreenSprite::GreenSprite(){}
	GreenSprite::GreenSprite(std::wstring* sFile) {
		if (!Load(sFile)) {
			Create(8, 8);
		}
	}

	void GreenSprite::Create(unsigned int width, unsigned int height) {
		pWidth = width;
		pHeight = height;
		m_Glyphs = new short[width * height];
		m_Colors = new short[width * height];
		for (int i = 0; i < width * height; i++) {
			m_Glyphs[i] = L' ';
			m_Colors[i] = COLORS::BLACK;
		}
	}

	void GreenSprite::SetGlyph(int x, int y, short c) {
		if (x < 0 || x  > pWidth || y < 0 || y > pHeight) {
			return;
		}
		else {
			m_Glyphs[y * pWidth + x] = c;
		}
	}

	void GreenSprite::SetColor(int x, int y, short c) {
		if (x < 0 || x  > pWidth || y < 0 || y > pHeight) {
			return;
		}
		else {
			m_Colors[y * pWidth + x] = c;
		}
	}

	short GreenSprite::GetGlyph(int x, int y) {
		if (x < 0 || x >= pWidth || y < 0 || y >= pHeight) {
			return L' ';
		}
		else {
			return m_Glyphs[y * pWidth + x];
		}
	}

	short GreenSprite::GetColor(int x, int y) {
		if (x < 0 || x >= pWidth || y < 0 || y >= pHeight) {
			return COLORS::BLACK;
		}
		else {
			return m_Colors[y * pWidth + x];
		}
	}

	short GreenSprite::SampleGlyph(float x, float y) {
		int sx = (int)(x * (float)pWidth);
		int sy = (int)(y * (float)pHeight - 1.0f);
		if (sx < 0 || sx >= pWidth || sy < 0 || sy >= pHeight) {
			return L' ';
		}
		else {
			return m_Glyphs[sy * pWidth + sx];
		}
	}

	short GreenSprite::SampleColor(float x, float y) {
		int sx = (int)(x * (float)pWidth);
		int sy = (int)(y * (float)pHeight - 1.0f);
		if (sx < 0 || sx >= pWidth || sy < 0 || sy >= pHeight) {
			return COLORS::BLACK;
		}
		else {
			return m_Colors[sy * pWidth + sx];
		}
	}

	bool GreenSprite::Save(std::wstring* sFile) {
		FILE* file = nullptr;
		_wfopen_s(&file, sFile->c_str(), L"wb");
		if (file == nullptr) {
			return false;
		}
		std::fwrite(&pWidth, sizeof(int), 1, file);
		std::fwrite(&pHeight, sizeof(int), 1, file);
		std::fwrite(m_Colors, sizeof(short), pWidth * pHeight, file);
		std::fwrite(m_Glyphs, sizeof(short), pWidth * pHeight, file);
		std::fclose(file);
		return true;
	}

	bool GreenSprite::Load(std::wstring* sFile) {
		delete[] m_Glyphs;
		delete[] m_Colors;
		pWidth = 0;
		pHeight = 0;
		FILE* file = nullptr;
		_wfopen_s(&file, sFile->c_str(), L"rb");
		if (file == nullptr) {
			return false;
		}
		std::fread(&pWidth, sizeof(int), 1, file);
		std::fread(&pHeight, sizeof(int), 1, file);
		Create(pWidth, pHeight);
		std::fread(m_Colors, sizeof(short), pHeight * pWidth, file);
		std::fread(m_Glyphs, sizeof(short), pHeight * pWidth, file);
		std::fclose(file);
		return true;
	}

}