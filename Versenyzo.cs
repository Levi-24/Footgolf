using System.Linq;

namespace CA230914_01
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public bool Kategoria { get; set; }
        public string Egyesulet { get; set; }
        public int[] Pontszamok { get; set; }
        public int Osszpont
        {
            get
            {
                int[] rendezett = Pontszamok.OrderBy(p => p).ToArray();
                int op = 0;
                if (rendezett[0] > 0) op += 10;
                if (rendezett[1] > 0) op += 10;
                for (int i = 2; i < rendezett.Length; i++)
                    op += rendezett[i];
                return op;
            }
        }

        public Versenyzo(string r)
        {
            string[] v = r.Split(';');
            Nev = v[0];
            Kategoria = v[1] == "Felnott ferfi";
            Egyesulet = v[2] == "n.a." ? null : v[2];
            Pontszamok = new int[8];
            for (int i = 0; i < Pontszamok.Length; i++)
                Pontszamok[i] = int.Parse(v[i + 3]);
        }
    }
}
