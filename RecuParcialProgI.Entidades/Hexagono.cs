using RecuuParcialProgI.Entidades;

namespace RecuParcialProgI.Entidades
{
    public class Hexagono
    {

        private int _Arista;
        private TipodeBorde tipodeBorde;

        public TipodeBorde TipoDeBorde
        {
            get { return tipodeBorde; }
            set { tipodeBorde = value; }
        }

        private ColorRelleno colorRelleno;

        public ColorRelleno ColorRelleno
        {
            get { return colorRelleno; }
            set { colorRelleno = value; }
        }
        public Hexagono(int arista, TipodeBorde borde, ColorRelleno color)
        {
            _Arista = arista;
            TipoDeBorde = borde;
            ColorRelleno = color;
        }


        public Hexagono()
        {

        }

        public int GetLado() => _Arista;

        public void SetLado(int arista)
        {
            if (arista > 0)
            {
                _Arista = arista;
            }
        }


        public object GetApotema() => Math.Sqrt((Math.Pow(_Arista, 2) - Math.Pow(_Arista / 2, 2)));

        public object GetArea() => 6*_Arista* Math.Sqrt((Math.Pow(_Arista, 2) - Math.Pow(_Arista / 2, 2)))/2;


        public object GetVolumen() => 6*_Arista;


    }
}
