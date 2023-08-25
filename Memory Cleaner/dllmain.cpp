// dllmain.cpp : 定义 DLL 应用程序的入口点。
#include "pch.h"
#include "Library.h"
#include "export.h"

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

int CleanMomery()
{
    OutputDebugString(L"AdjustTokenPrivilegesForNT - 提权中\n");
    if (!AdjustTokenPrivilegesForNT())
    {
        OutputDebugString(L"失败\n");
        return 1;
    }
    else
    {
        OutputDebugString(L"成功\n");

        OutputDebugString(L"清理工作集\n");
        if (!EmptyAllSet())
        {
            OutputDebugString(L"失败\n");
            return 2;
        }
        else
        {
            OutputDebugString(L"成功\n");

            OutputDebugString(L"SE_INCREASE_QUOTA_NAME - 提权中\n");
            if (!EnableSpecificPrivilege(SE_INCREASE_QUOTA_NAME))
            {
                OutputDebugString(L"失败\n");
                return 3;
            }
            else
            {
                OutputDebugString(L"成功\n");

                OutputDebugString(L"刷新系统页面缓存\n");
                if (SetSystemFileCacheSize(-1, -1, 0))
                {
                    OutputDebugString(L"失败\n");
                    return 4;
                }
                else
                {
                    OutputDebugString(L"成功\n");

                    OutputDebugString(L"生成并释放内存 - 2G\n");
                    deepClean();
                    OutputDebugString(L"完成\n");
                    return 0;
                }
            }
        }
    }
}