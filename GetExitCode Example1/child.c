#include <stdio.h>
#include <stdlib.h>
int main(int argc, char **argv)//child process
{
    if (argc <= 1)
    {
        printf("hello without args\n");
        return 0;
    }
    else
    {
        for (int i = 1; i < argc; i++)
        {
            printf("%s\n", argv[i]);
        }
    }
    return argc - 1;
}