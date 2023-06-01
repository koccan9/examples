#include <stdio.h>
#include <stdlib.h>
const int PIN = 443553;//the target PIN that is gonna be cracked
const int upper = 0;
const int lower = 999999;
int main() {
	for (int i = 0; i < 999999; i++) {//Method 1 for cracking a Integer PIN. Works if the PIN is stored as Integer
		if (PIN == i) {//if cracked then break loop
			printf("Incremental Brute Force Cracked The PIN '%d'\n", i);
			break;
		}
	}
	while (1) {//Method 2 for cracking a Integer PIN
		int num = (rand() %
			(upper - lower + 1)) + lower;
		if (num == PIN) {//if cracked then break loop
			printf("Random Brute Force Cracked The PIN '%d'", num);
			break;
		}
	}
	printf("*****\nPIN is %d\n", PIN);
	getchar();
}