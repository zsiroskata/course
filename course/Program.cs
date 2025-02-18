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
Console.WriteLine("1.feladat");
Console.WriteLine($"{courses.Count} adata van a fileba.");

//2. Mennyi a hallgató átlaga backend fejlesztés modulból
Console.WriteLine("\n2.feladat");
var avg = courses.Average(x =>x.Backend());
Console.WriteLine($"Backend átlag:{avg}");

//3. Melyik hallgató az osztályelső (akinek a legjobb az eredményeinek összege minden tantárgyból)?
Console.WriteLine("\n3.feladat");
var bs = courses.OrderByDescending(x => x.Result.Sum())  
    .Select(x => x.Name).FirstOrDefault();  

Console.WriteLine($"osztályelső:\t {bs} ");

//4. Mennyi a férfiak aránya a képzésen?
Console.WriteLine("\n4.feladat");
int m = courses.Count(course => course.Gender);

double arany = (double)m / courses.Count * 100;

Console.WriteLine($"fiúk aránya: {arany:F2}%");

//5. Melyik női hallgató a legjobb webfejlesztésből? (a legmagasabb a frontend + backend muduljainak összpontszáma)
Console.WriteLine("\n5.feladat");
var f = courses.Where(x => !x.Gender).OrderByDescending(x => x.Frontend() + x.Backend())
    .Select(x => x.Name).FirstOrDefault();

Console.WriteLine($"legjobb női webfejlesztő:\t{f}");

//6. A tanfolyam ára $2600, kik azok a hallgatók, akik már előfinanszírozták a tanfolyam árának teljes összegét?
Console.WriteLine("\n6.feladat");
var p = courses.Where(x => x.Payment == 2600)
    .Select(x=> x.Name);
Console.WriteLine("hallagtok akik már fizettek:");
foreach (var item in p)
{
    Console.WriteLine($"\t{item}");
}


//7. Kérje be a program egy hallgató nevét, ha van ilyen hallgató, akkor írja ki, hogy mely tanegységekből kell javítóvizsgát tennie (ha kell)! Abból a tanegységből kell javítóvizsgát tenni, ahol az elért eredmény nem éri el az 51%-ot.
Console.WriteLine("\n7.feladat");

Console.Write("adja meg a hallgató nevét: ");
string sName= Console.ReadLine();
var student = courses.FirstOrDefault(x => x.Name.ToLower() == sName.ToLower());

if (student == null)
{
    Console.WriteLine("nincs ilyen hallagató");
}
else
{
    List<string> failedSubjects = student.GetFailedSubjects();
    if (failedSubjects.Count > 0)
    {
        Console.WriteLine($"{student.Name} tantárgyakból kell javítót tennie:");
        Console.WriteLine(string.Join(", ", failedSubjects));
    }
    else
    {
        Console.WriteLine($"{student.Name} nem kell javítót tennie");
    }
}

//8. Határozza meg azon hallgatók számát, akik legalább egy modulból 100%-ot teljesítettek, és egyik modulból sem kell javítóvizsgát tenniük.
Console.WriteLine("\n8.feladat");
var perfect = courses.Count(x => x.Result.Contains(100) && x.GetFailedSubjects().Count == 0);

Console.WriteLine($"összesen  {perfect} db ember van, akinek 100% modul & nem bukott meg semmiből:");

//9. Írja ki a képernyőre, hogy modulonként hány tanulónak kell javítóvizsgát tennie.
Console.WriteLine("\n9.feladat");
Dictionary<string, int> failedModules = new Dictionary<string, int>();

for (int i = 0; i < Course.Subjects.Length; i++)
{
    int failedCount = courses.Count(student => student.Result[i] < 51);
    failedModules[Course.Subjects[i]] = failedCount;
}

Console.WriteLine("modulonkénti javitók száma:");
foreach (var item in failedModules)
{
    Console.WriteLine($"\t{item.Key}: \t{item.Value} hallgató");
}

//10. Rendezze a hallgatókat családnév szerint ABC sorrendbe, és írja ki egy fileba az átlageredményükkel együtt (feltételezheti, hogy minden hallgató neve 2 részből áll, szóköz szeparálja, és a második név a családnév)
Console.WriteLine("\n10.feladat");

List<Course> sortedStudents = courses.OrderBy(x => x.Name.Split(' ')[1]).ToList();
using (StreamWriter writer = new StreamWriter(@"..\..\..\src\atlag.txt"))
{
  
    foreach (var item in sortedStudents)
    {
        var avg1 = item.Result.Average();
        writer.WriteLine($"{ item.Name}: {avg1:F2}%");
    }
}

Console.WriteLine("hallgatók családnév szerint rendezve");
