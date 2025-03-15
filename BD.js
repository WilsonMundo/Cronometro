let db;

async function setupIndexedDB() {
    if (!window.indexedDB) {
        console.error("Tu navegador no soporta IndexedDB");
        return;
    }
    console.log("Configurando");
    db = new Dexie("CronometroDB");
    db.version(1).stores({
        Competidores: "++idCompetidor,numeroCompetido,nombre,distanciaRecorrida,tiempoFinal,velocidadPromedio,estado"
    });
}

async function insertOrUpdateCompetidor(competidor) {
    try {
      
        await db.Competidores.add(competidor);
    } catch (error) {
        console.error(`Error al insertar o actualizar competidor: ${error.message}`);
        throw new Error(`Error al insertar o actualizar competidor: ${error.message}`);
    }
}
async function getAllCompetidores() {
    try {        
        const data = await db.Competidores.toArray();
        return data ? data : null;
    } catch (error) {
        throw new Error(`Error al obtener todos los competidores: ${error.message}`);
    }
}

async function getCompetidorByNombre(nombre) {
    try {        
        const data = await db.Competidores.where("nombre").equals(nombre).toArray();
        return data.length > 0 ? data[0] : null;
    } catch (error) {
        throw new Error(`Error al obtener el competidor por nombre: ${error.message}`);
    }
}


export {
    insertOrUpdateCompetidor, getCompetidorByNombre, getAllCompetidores,setupIndexedDB
}