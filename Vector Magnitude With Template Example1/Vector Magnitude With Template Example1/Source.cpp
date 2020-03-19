#include <iostream>
#include <cmath>
using namespace std;
template <typename T>
struct Vector4 {
	T x, y, z, w;
	double Magnitude() {
		return sqrt(x * x + y * y + z * z + w * w);
	}
	friend ostream& operator<<(ostream& ref, const Vector4& vec4) {//ostream inserter
		ref << vec4.x;
		ref << " ";
		ref << vec4.y;
		ref << " ";
		ref << vec4.z;
		ref << " ";
		ref << vec4.w;
		return ref;
	}
};
int main() {
	Vector4<double> VecDouble{ 4,8,3, 5 };
	cout << VecDouble << "\n";
	cout << VecDouble.Magnitude() << "\n\n";
	Vector4<int> VecInt{ 3,3,3,7 };
	cout << VecInt << "\n";
	cout << VecInt.Magnitude() << "\n\n";
}