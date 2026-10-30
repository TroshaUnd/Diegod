// Provincias y localidades iniciales (Argentina). Se cargan solo si la tabla esta vacia.
// Para agregar mas localidades basta con insertarlas en la tabla Localidades.
using System.Collections.Generic;

namespace Diegod.Datos
{
    internal static class SemillaGeografica
    {
        public static readonly (string Provincia, string[] Localidades)[] ProvinciasYLocalidades =
        {
            ("Buenos Aires", new[] { "La Plata", "Mar del Plata", "Bahía Blanca", "Tandil", "Olavarría", "Pergamino", "Junín", "Azul", "Necochea", "Zárate", "Campana", "San Nicolás", "Luján", "Mercedes", "Chivilcoy", "Tres Arroyos", "Pilar", "Escobar", "San Isidro", "Tigre", "Quilmes", "Lomas de Zamora", "Lanús", "Avellaneda", "Morón", "Merlo", "Moreno", "San Martín", "Tres de Febrero", "La Matanza", "Florencio Varela", "Berazategui", "Ezeiza", "Cañuelas", "Dolores", "Chascomús" }),
            ("Ciudad Autónoma de Buenos Aires", new[] { "Ciudad Autónoma de Buenos Aires" }),
            ("Catamarca", new[] { "San Fernando del Valle de Catamarca", "Andalgalá", "Belén", "Tinogasta", "Santa María", "Fiambalá", "Recreo" }),
            ("Chaco", new[] { "Resistencia", "Presidencia Roque Sáenz Peña", "Villa Ángela", "Charata", "General San Martín", "Barranqueras", "Fontana" }),
            ("Chubut", new[] { "Rawson", "Comodoro Rivadavia", "Trelew", "Puerto Madryn", "Esquel", "Sarmiento", "Gaiman" }),
            ("Córdoba", new[] { "Córdoba", "Villa Carlos Paz", "Río Cuarto", "Villa María", "San Francisco", "Alta Gracia", "Río Tercero", "Bell Ville", "Jesús María", "Cosquín", "La Falda", "Villa Dolores", "Cruz del Eje", "Laboulaye", "Marcos Juárez", "Mina Clavero" }),
            ("Corrientes", new[] { "Corrientes", "Goya", "Paso de los Libres", "Mercedes", "Curuzú Cuatiá", "Santo Tomé", "Esquina", "Bella Vista" }),
            ("Entre Ríos", new[] { "Paraná", "Concordia", "Gualeguaychú", "Concepción del Uruguay", "Gualeguay", "Chajarí", "Victoria", "Villaguay", "Colón", "La Paz" }),
            ("Formosa", new[] { "Formosa", "Clorinda", "Pirané", "El Colorado", "Ibarreta" }),
            ("Jujuy", new[] { "San Salvador de Jujuy", "Palpalá", "San Pedro", "Libertador General San Martín", "Humahuaca", "La Quiaca", "Perico", "Tilcara" }),
            ("La Pampa", new[] { "Santa Rosa", "General Pico", "Toay", "General Acha", "Eduardo Castex", "Realicó" }),
            ("La Rioja", new[] { "La Rioja", "Chilecito", "Aimogasta", "Chamical", "Chepes", "Famatina" }),
            ("Mendoza", new[] { "Mendoza", "San Rafael", "Godoy Cruz", "Guaymallén", "Las Heras", "Maipú", "Luján de Cuyo", "San Martín", "Rivadavia", "Tunuyán", "Malargüe", "General Alvear" }),
            ("Misiones", new[] { "Posadas", "Oberá", "Eldorado", "Puerto Iguazú", "Apóstoles", "Leandro N. Alem", "Montecarlo", "Jardín América", "San Vicente" }),
            ("Neuquén", new[] { "Neuquén", "Cutral Có", "Plottier", "Centenario", "Zapala", "San Martín de los Andes", "Junín de los Andes", "Villa La Angostura", "Rincón de los Sauces" }),
            ("Río Negro", new[] { "Viedma", "San Carlos de Bariloche", "General Roca", "Cipolletti", "Villa Regina", "Allen", "Cinco Saltos", "El Bolsón", "Río Colorado" }),
            ("Salta", new[] { "Salta", "San Ramón de la Nueva Orán", "Tartagal", "General Güemes", "Metán", "Cafayate", "Rosario de la Frontera", "Cerrillos" }),
            ("San Juan", new[] { "San Juan", "Rawson", "Rivadavia", "Chimbas", "Pocito", "Santa Lucía", "Caucete", "Jáchal", "Albardón" }),
            ("San Luis", new[] { "San Luis", "Villa Mercedes", "Merlo", "La Punta", "Justo Daract", "Buena Esperanza" }),
            ("Santa Cruz", new[] { "Río Gallegos", "Caleta Olivia", "Pico Truncado", "Puerto Deseado", "El Calafate", "Las Heras", "Puerto San Julián", "Río Turbio" }),
            ("Santa Fe", new[] { "Santa Fe", "Rosario", "Rafaela", "Venado Tuerto", "Reconquista", "Santo Tomé", "Villa Gobernador Gálvez", "San Lorenzo", "Esperanza", "Casilda", "Cañada de Gómez", "Sunchales", "Funes", "Granadero Baigorria", "Villa Constitución" }),
            ("Santiago del Estero", new[] { "Santiago del Estero", "La Banda", "Termas de Río Hondo", "Frías", "Añatuya", "Quimilí", "Monte Quemado" }),
            ("Tierra del Fuego", new[] { "Ushuaia", "Río Grande", "Tolhuin" }),
            ("Tucumán", new[] { "San Miguel de Tucumán", "Yerba Buena", "Concepción", "Banda del Río Salí", "Tafí Viejo", "Aguilares", "Monteros", "Famaillá", "Lules" }),
        };
    }
}
