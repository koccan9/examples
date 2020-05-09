#include <stdio.h>//https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getexitcodeprocess
#include <Windows.h>//https://docs.microsoft.com/en-us/windows/win32/procthread/creating-processes
int main()//parent process
{
    STARTUPINFO si;
    PROCESS_INFORMATION pi;
    ZeroMemory(&si, sizeof(si));
    ZeroMemory(&pi, sizeof(pi));
    si.cb = sizeof(si);
    if (!CreateProcess(NULL, "./calle deneme 123 423 asdf", NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi))
    {
        printf("CreateProcess GetLastError %d\n", GetLastError());
        exit(EXIT_FAILURE);
    }
    WaitForSingleObject(pi.hProcess, INFINITE); //wait until process terminates.
    DWORD exit_code = 0;                        //child process exit code.
    if (!GetExitCodeProcess(pi.hProcess, &exit_code))
    {
        printf("GetExitCodeProcess GetLastError %d\n", GetLastError());
        exit(EXIT_FAILURE);
    }
    printf("*****************\ncalle exit code is %d\n", exit_code);
}
