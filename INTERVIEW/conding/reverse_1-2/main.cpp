#include <string>
#include <iostream>

using namespace std;

void reverse1_1(char * str)
{
    char * end = str;
    char tmp;
    while (*end) ++end; // finding the end
    --end; //one char back
    while (str < end)
    {
        tmp = * str;
        * str ++ = * end;
        * end -- = tmp;
    }
}

int main()
{
    char * str;

    // 1.2
    str = "aftrs\0";
    //reverse1_1(str);
    cout << str << endl;


    return 0;
}
