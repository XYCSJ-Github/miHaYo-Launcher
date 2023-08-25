#pragma once
#include "pch.h"
#define SE_INCREASE_QUOTA_NAME  TEXT("SeIncreaseQuotaPrivilege")

void deepClean();
BOOL EmptyAllSet();
bool AdjustTokenPrivilegesForNT();
bool EnableSpecificPrivilege(LPCTSTR lpPrivilegeName);