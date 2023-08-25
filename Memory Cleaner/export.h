#pragma once
#ifdef MAKEDLLEXPORT
#define DLLEXPORT extern "C" __declspec(dllexport)
#else
#define DLLEXPORT extern "C" __declspec(dllimport)
#endif

DLLEXPORT int CleanMomery();