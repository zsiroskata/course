using course;
using System.Text;

List<Course> courses = new();

using StreamReader sr = new StreamReader(
    path: @"..\..\..\src\course.txt",
    encoding: Encoding.UTF8);

while (!sr.EndOfStream)
{
    courses.Add(new Course(sr.ReadLine()));
}

sr.Close();

//1.Hány hallgató adatait tartalmazza a file?
Console.WriteLine($"{courses.Count} adata van a fileba.");

//2. Mennyi a hallgató átlaga backend fejlesztés modulból
var avg = courses.Average(x =>x.Backend());
Console.WriteLine($"Backend átlag:{avg}");

//3. Melyik hallgató az osztályelső (akinek a legjobb az eredményeinek összege minden tantárgyból)?


//4. Mennyi a férfiak aránya a képzésen?
int c = courses.Count(course => course.Gender == true);

double arany = (double)c / courses.Count * 100;

Console.WriteLine($"fiúk aránya: {arany:F2}%");

//5. Melyik női hallgató a legjobb webfejlesztésből? (a legmagasabb a frontend + backend muduljainak összpontszáma)

//6. A tanfolyam ára $2600, kik azok a hallgatók, akik már előfinanszírozták a tanfolyam árának teljes összegét?
//7. Kérje be a program egy hallgató nevét, ha van ilyen hallgató, akkor írja ki, hogy mely tanegységekből kell
//javítóvizsgát tennie (ha kell)! Abból a tanegységből kell javítóvizsgát tenni, ahol az elért eredmény nem éri el
//az 51%-ot.
//8. Határozza meg azon hallgatók számát, akik legalább egy modulból 100%-ot teljesítettek, és egyik modulból
//sem kell javítóvizsgát tenniük.
//9. Írja ki a képernyőre, hogy modulonként hány tanulónak kell javítóvizsgát tennie.
//10. Rendezze a hallgatókat családnév szerint ABC sorrendbe, és írja ki egy fileba az átlageredményükkel együtt
//(feltételezheti, hogy minden hallgató neve 2 részből áll, szóköz szeparálja, és a második név a családnév)