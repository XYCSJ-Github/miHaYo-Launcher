#include "Library.h"
#include "pch.h"

bool EnableSpecificPrivilege(LPCTSTR lpPrivilegeName)
{
    HANDLE hToken = NULL;
    TOKEN_PRIVILEGES Token_Privilege;
    BOOL bRet = TRUE;
    do
    {
        if (0 == OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, &hToken))
        {
            //OutputDebugView(_T("OpenProcessToken Error"));
            bRet = FALSE;
            break;
        }
        if (0 == LookupPrivilegeValue(NULL, lpPrivilegeName, &Token_Privilege.Privileges[0].Luid))
        {
            //OutputDebugView(_T("LookupPrivilegeValue Error"));
            bRet = FALSE;
            break;
        }
        Token_Privilege.PrivilegeCount = 1;
        Token_Privilege.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
        //Token_Privilege.Privileges[0].Luid.LowPart=17;//SE_BACKUP_PRIVILEGE 
        //Token_Privilege.Privileges[0].Luid.HighPart=0; 
        if (0 == AdjustTokenPrivileges(hToken, FALSE, &Token_Privilege, sizeof(Token_Privilege), NULL, NULL))
        {
            //OutputDebugView(_T("AdjustTokenPrivileges Error"));
            bRet = FALSE;
            break;
        }
    } while (false);
    if (NULL != hToken)
    {
        CloseHandle(hToken);
    }
    return bRet;
}

bool AdjustTokenPrivilegesForNT()
{
    HANDLE hToken;
    TOKEN_PRIVILEGES tkp;

    // Get a token for this process.

    OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, &hToken);

    // Get the LUID for the EmptyWorkingSet privilege.

    LookupPrivilegeValue(NULL, SE_DEBUG_NAME, &tkp.Privileges[0].Luid);

    tkp.PrivilegeCount = 1; // one privilege to set   
    tkp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;

    // Get the EmptyWorkingSet privilege for this process.

    return AdjustTokenPrivileges(hToken, FALSE, &tkp, 0, (PTOKEN_PRIVILEGES)NULL, 0);
}

BOOL EmptyAllSet()
{
    HANDLE SnapShot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
    if (SnapShot == NULL)
    {
        return FALSE;
    }
    PROCESSENTRY32 ProcessInfo;//声明进程信息变量
    ProcessInfo.dwSize = sizeof(ProcessInfo);//设置ProcessInfo的大小
    //返回系统中第一个进程的信息
    BOOL Status = Process32First(SnapShot, &ProcessInfo);
    while (Status)
    {
        HANDLE hProcess = OpenProcess(PROCESS_ALL_ACCESS, TRUE, ProcessInfo.th32ProcessID);
        if (hProcess)
        {
            //printf("正在清理进程ID：%d 的内存\n",ProcessInfo.th32ProcessID);
            SetProcessWorkingSetSize(hProcess, -1, -1);
            //内存整理
            EmptyWorkingSet(hProcess);
            CloseHandle(hProcess);
        }
        //获取下一个进程的信息
        Status = Process32Next(SnapShot, &ProcessInfo);
    }
    return TRUE;
}

void deepClean()
{
    const int num = 1000;
    int size = 500000;
    int* a[num];
    for (int i = 0; i < num; i++)
    {
        a[i] = new int[size];
    }
    for (int i = 0; i < num; i++)
    {
        delete a[i];
    }
}