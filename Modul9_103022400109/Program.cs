class Program
{
    static void Main(string[] args)
    {
        CovidConfig configClass = new CovidConfig();

        RunApp(configClass);

        Console.WriteLine("\n--- Mengubah Satuan ---");
        configClass.UbahSatuan();

        RunApp(configClass);
    }

    static void RunApp(CovidConfig configObj)
    {
        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {configObj.conf.satuan_suhu}: ");
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = int.Parse(Console.ReadLine());

        bool suhuValid = false;
        if (configObj.conf.satuan_suhu == "celcius")
        {
            if (suhu >= 36.5 && suhu <= 37.5) suhuValid = true;
        }
        else
        {
            if (suhu >= 97.7 && suhu <= 99.5) suhuValid = true;
        }

        bool hariValid = hari < configObj.conf.batas_hari_deman;

        if (suhuValid && hariValid)
        {
            Console.WriteLine(configObj.conf.pesan_diterima);
        }
        else
        {
            Console.WriteLine(configObj.conf.pesan_ditolak);
        }
    }
}