#include <stdio.h>
#include <string.h>
#include <stdlib.h>
typedef struct {		//https://www.geeksforgeeks.org/difference-structure-union-c/
	char name[50];
	union {//C style,generic programming
		long int dword;
		short int word;
	}age;
}Person;
int main() {
	Person p;
	p.age.dword = 24;
	strcpy(p.name, "Damar Programlama");
	printf("%d %s\n", p.age, p.name);
	Person p2;
	p2.age.word = 24;
	strcpy(p2.name, "Damar Programlama2");
	printf("%d %s\n", p2.age, p2.name);
}