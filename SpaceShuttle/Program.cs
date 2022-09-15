class Program
{
    class Datas
    {
        private string code { get; set; } //A küldetés kódja
        private string launcDate { get; set; } //az űrsikló kilövésének dátuma
        private string shutName { get; set; } //a küldetést végző űrsikló neve
        private int day { get; set; } //hány napot
        private int hour { get; set; } //és hány órát
        private string place { get; set; } //a légitámaszpont neve, ahol a sikló a küldetés végeztével landolt
        public int crew { get; set; } //mekkora legénységgel szállt fel a sikló

        public Datas (String line) 
        {
            string[] array = line.Split(';');
            code = array[0];
            launcDate = array[1];
            shutName = array[2];
            day = int.Parse(array[3]);
            hour = int.Parse(array[4]);
            place = array[5];
            crew = int.Parse(array[6]);
        }

    }

    static void Main(string[] args)
    {
        List <Datas> list = new List <Datas> ();
        FileStream fs = new FileStream("kuldetesek.csv", FileMode.Open);
        StreamReader sr = new StreamReader(fs);

        while (!sr.EndOfStream)
        {
            Datas e = new Datas(sr.ReadLine());
            list.Add(e);
        }
        fs.Close();
        sr.Close();

        //3.feladat
        Console.WriteLine($"3. feladat:\n\tÖsszesen {list.Count} alkalommal indítottak űrhajót.");

        //4.feladat
        int sum = 0;
        for (int i = 0; i < list.Count; i++)
        {
           sum += list[i].crew;
        }
        Console.WriteLine($"4. feladat:\n\t{sum} utas indult az űrbe összesen.");

        //5.feladat
        int less = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].crew < 5)
            {
                less++;
            }
        }
        Console.WriteLine($"5. feladat:\n\tÖsszesen {less} alkalommal küldtek kevesebb, mint 5 embert az űrbe.");

        //6.feladat

        Console.WriteLine($"6. feladat:\n\t asztronauta volt a Columbia fedélzetén annak utolsó útján.");

        Console.ReadKey();
    }
}