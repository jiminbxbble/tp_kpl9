using System;
using System.IO;
using System.Text.Json;

public class Config
{
    public string satuan_suhu { get; set; }
    public int batas_hari_deman { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    public Config() { }

    public Config(string satuan, int batas, string ditolak, string diterima)
    {
        satuan_suhu = satuan;
        batas_hari_deman = batas;
        pesan_ditolak = ditolak;
        pesan_diterima = diterima;
    }
}

public class CovidConfig
{
    public Config conf;
    private const string filePath = "covid_config.json";

    public CovidConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch
        {
            SetDefault();
            WriteConfigFile();
        }
    }

    private void SetDefault()
    {
        conf = new Config("celcius", 14,
            "Anda tidak diperbolehkan masuk ke dalam gedung ini",
            "Anda dipersilahkan untuk masuk ke dalam gedung ini");
    }

    private void ReadConfigFile()
    {
        string jsonString = File.ReadAllText(filePath);
        conf = JsonSerializer.Deserialize<Config>(jsonString);
    }

    private void WriteConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(conf, options);
        File.WriteAllText(filePath, jsonString);
    }

    public void UbahSatuan()
    {
        conf.satuan_suhu = (conf.satuan_suhu == "celcius") ? "fahrenheit" : "celcius";
        WriteConfigFile();
    }
}