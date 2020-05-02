#include <stdio.h>
#include <stdlib.h>
typedef struct {
	int a, b;
}Numbers;
void Foo(Numbers* num) {
	__asm {
		mov eax, num
		mov [eax], 5
		mov [eax + 4], 7;
	}
}
int main() {
	Numbers n = { 88,88 };
	Foo(&n);
	printf("%d %d\n", n.a, n.b);
	system("pause");
}