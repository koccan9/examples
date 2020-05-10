#include <stdio.h>
int a()
{
    printf("safdsafsadf\n");
    return 55;
}
int main()
{
    printf("sizeof int is %llu\n", sizeof(a())); //sizeof operator does not cause side effects
}