namespace MonthEnumUsage
{
    internal class Program
    {
        [Flags]
        public enum Month
        {
            Enero = 1,              //000000000001
            Febrero = 2,            //000000000010
            Marzo = 4,              //000000000100
            Abril = 8,              //000000001000
            Mayo = 16,              //000000010000
            Junio = 32,             //000000100000
            Julio = 64,             //000001000000
            Agosto = 128,           //000010000000
            Septiembre = 256,       //000100000000
            Octubre = 512,          //001000000000
            Noviembre = 1024,       //010000000000
            Diciembre = 2048        //100000000000
        }
        public enum TipoReporte
        {
            Sum,
            Avg,
            Min,
            Max
        }

        static void Main(string[] args)
        {
            decimal[] gastoAnual = new decimal[12];
            LeerGastosMensuales(gastoAnual);

            Month meses = AsignarMesesAConsultar(Month.Marzo, Month.Diciembre, Month.Mayo, Month.Enero);

            decimal[] gastosAConsultar = TraerReporte(meses, gastoAnual);

            SeleccionarTipoReporte(TipoReporte.Max, meses, gastosAConsultar);
        }

        public static void SeleccionarTipoReporte(TipoReporte tipo, Month meses, decimal[] data)
        {
            switch(tipo)
            {
                case TipoReporte.Sum:
                    Console.WriteLine($"Gasto total de los meses {meses}: {data.Sum()}");
                    break;
                case TipoReporte.Avg:
                    Console.WriteLine($"Promedio total del gasto de los meses {meses}: {data.Average()}");
                    break;
                case TipoReporte.Min:
                    Console.WriteLine($"Gasto mínimo entre los meses {meses}: {data.Min()}");
                    break;
                case TipoReporte.Max:
                    Console.WriteLine($"Gasto máximo entre los meses {meses}: {data.Max()}");
                    break;
            }
        }

        static decimal[] TraerReporte(Month meses, decimal[] data)
        {
            int cantidadMeses = ContarBits((int)meses);
            decimal[] reporte = new decimal[cantidadMeses];

            int validadorMes = 0;
            int indice = 0;
            int contador = 0;

            foreach(Month mes in Enum.GetValues(typeof(Month)))
            {
                validadorMes = (int)meses & (int)mes;

                if(validadorMes > 0 )
                {
                    indice = (int)Math.Round(Math.Log((int)mes, 2));
                    reporte[contador] = data[indice];
                    contador++;
                }
            }

            return reporte;
        }

        public static void LeerGastosMensuales(decimal[] data)
        {
            data[0] = 5000;
            data[1] = 1100;
            data[2] = 652;
            data[3] = 7895;
            data[4] = 421;
            data[5] = 9658;
            data[6] = 4568;
            data[7] = 985;
            data[8] = 3000;
            data[9] = 4520;
            data[10] = 6520;
            data[11] = 22000;
        }
        public static Month AsignarMesesAConsultar(params Month[] meses)
        {
            int resultado = 0;

            if (meses is not null)
            {
                foreach(Month mes in meses)
                {
                    resultado |= (int)mes;
                }
            }

            return (Month)resultado;
        }
        public static int ContarBits(int value)
        {
            int count = 0;

            while(value != 0)
            {
                //value = value & (value - 1);
                value &= (value - 1);
                count++;
            }

            return count;
        }
    }
}