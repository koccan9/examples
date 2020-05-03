#include <iostream>
#include <string>
using namespace std;
struct Person {
	string name, surname;
	virtual string ToGUI()const {
		return name + " " + surname;
	}
};
struct DerivedPerson:public Person {
	string ID;
	string ToGUI()const override {
		return Person::ToGUI() + " " + ID;
	}
};
void OOP(const Person& ref) {
	cout << ref.ToGUI() << endl;
}
int main() {
	DerivedPerson p;
	p.ID = "ID";
	p.name = "name";
	p.surname = "surname";
	OOP(p);
	Person p2;
	p2.name = "name";
	p2.surname = "surname";
	OOP(p2);
}