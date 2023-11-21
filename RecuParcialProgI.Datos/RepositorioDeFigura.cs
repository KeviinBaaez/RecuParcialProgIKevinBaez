using RecuParcialProgI.Entidades;
using RecuuParcialProgI.Entidades;

namespace RecuParcialProgI.Datos
{
    public class RepositorioDeFigura
    {
        private readonly string _archivo = Environment.CurrentDirectory + "\\Objetos.txt";
        private readonly string _archivoCopia = Environment.CurrentDirectory + "\\Objetos.bak";
        private List<Hexagono> listaHexagonos;

        public RepositorioDeFigura()
        {
            listaHexagonos = new List<Hexagono>();
            LeerDatos();
        }
        public List<Hexagono> GetLista()
        {
            return listaHexagonos;
        }
        private void LeerDatos()
        {
            if (File.Exists(_archivo))
            {
                var lector = new StreamReader(_archivo);
                while (!lector.EndOfStream)
                {
                    string lineaLeida = lector.ReadLine();
                    Hexagono objeto = ConstruirObjeto(lineaLeida);
                    listaHexagonos.Add(objeto);
                }
                lector.Close();
            }
        }
        public void Editar(int ladoAnterior, Hexagono HexagonoEditar)
        {
            using (var lector = new StreamReader(_archivo))
            {
                using (var escritor = new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida = lector.ReadLine();
                        Hexagono objeto = ConstruirObjeto(lineaLeida);
                        if (ladoAnterior != objeto.GetLado())
                        {
                            escritor.WriteLine(lineaLeida);
                        }
                        else
                        {
                            lineaLeida = ConstruirLinea(HexagonoEditar);
                            escritor.WriteLine(lineaLeida);
                        }
                    }
                }
            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);
        }
        private Hexagono ConstruirObjeto(string? lineaLeida)
        {
            var campos = lineaLeida.Split('|');
            int lado = int.Parse(campos[0]);
            ColorRelleno color = (ColorRelleno)int.Parse(campos[1]);
            TipodeBorde borde = (TipodeBorde)int.Parse(campos[2]);
            Hexagono c = new Hexagono(lado, borde, color);
            return c;
        }

        public void Agregar(Hexagono objeto)
        {
            using (var escritor = new StreamWriter(_archivo, true))
            {
                string lineaEscribir = ConstruirLinea(objeto);
                escritor.WriteLine(lineaEscribir);
                escritor.Close();
            }


            listaHexagonos.Add(objeto);
        }
        private string ConstruirLinea(Hexagono objeto)
        {
            return $"{objeto.GetLado()}|{objeto.TipoDeBorde.GetHashCode()}|{objeto.ColorRelleno.GetHashCode()}";

        }
        public int GetCantidad(int? valorFiltro = null)
        {
            if (valorFiltro != null)
            {
                return listaHexagonos.Count(c => c.GetLado() >= valorFiltro);
            }
            return listaHexagonos.Count;
        }
        public void Borrar(Hexagono objetoBorrar)
        {
            using (var lector = new StreamReader(_archivo))
            {
                using (var escritor = new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida = lector.ReadLine();
                        Hexagono objetoLeido = ConstruirObjeto(lineaLeida);
                        if (objetoBorrar.GetLado() != objetoLeido.GetLado())
                        {
                            escritor.WriteLine(lineaLeida);
                        }
                    }
                }
            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);
            listaHexagonos.Remove(objetoBorrar);
        }
        public bool Existe(Hexagono tringulo)
        {
            listaHexagonos.Clear();
            LeerDatos();
            foreach (var itemTringulo in listaHexagonos)
            {
                if (itemTringulo.GetLado() == tringulo.GetLado())
                {
                    return true;
                }
            }
            return false;
        }
        public List<Hexagono> Filtrar(int intValor)
        {
            return listaHexagonos.Where(c => c.GetLado() >= intValor).ToList();
        }

        public List<Hexagono> OrdenarAsc()
        {
            return listaHexagonos.OrderBy(c => c.GetLado()).ToList();
        }


        public List<Hexagono> OrdenarDesc()
        {
            return listaHexagonos.OrderByDescending(c => c.GetLado()).ToList();
        }
    }
}
