namespace FsApiAccess.Models
{
    public class ApiClasificationResponseModel
    {
        public List<Klasifikacia> Klasifikacie { get; set; }
        public List<Lokacia> Lokacie { get; set; }

    }

    public class Klasifikacia
    {
        public string Kod { get; set; }
        public Nazov Nazov { get; set; }
        public string NadriadenaKlasifikacia { get; internal set; }
    }
    public class Lokacia
    {
        public string Kod { get; set; }
        public Nazov Nazov { get; set; }
        public string NadriadenaKlasifikacia { get; internal set; }
    }

    public class Nazov
    {
        public string En { get; set; }
        public string Sk { get; set; }
    }
}

