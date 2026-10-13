// la api vive en el mismo servidor, por eso la direccion base queda vacia
const BASE = "";

// nombres de los codigos que mostramos en el panel de respuesta
const NOMBRES_ESTADO = {
  200: "OK",
  201: "Created",
  400: "Bad Request",
  404: "Not Found",
  409: "Conflict",
  415: "Unsupported Media Type",
  500: "Internal Server Error"
};

// lote de ejemplo que aparece en el cuadro de texto
const LOTE_EJEMPLO = {
  movimientos: [
    { codigo: "REP-003", tipo: "entrada", cantidad: 15, motivo: "compra a proveedor" },
    { codigo: "REP-001", tipo: "salida", cantidad: 5, motivo: "venta mostrador" },
    { codigo: "REP-002", tipo: "entrada", cantidad: 6, motivo: "reposicion" }
  ]
};

// atajo para buscar un elemento por su id
function el(id) {
  return document.getElementById(id);
}

// envia una peticion y devuelve el codigo de estado junto con el cuerpo ya convertido
// si crudo es verdadero, el cuerpo se envia como texto sin convertir
async function llamar(metodo, url, cuerpo, crudo) {
  // opciones de la peticion
  const opciones = { method: metodo, headers: {} };

  // solo las peticiones con cuerpo llevan la cabecera de tipo de contenido
  if (cuerpo !== undefined) {
    opciones.headers["Content-Type"] = "application/json";
    opciones.body = crudo ? cuerpo : JSON.stringify(cuerpo);
  }

  // fetch devuelve una promesa: await espera la respuesta
  const respuesta = await fetch(BASE + url, opciones);

  // leemos el cuerpo como texto y despues intentamos convertirlo a objeto
  const texto = await respuesta.text();
  let datos = null;
  if (texto) {
    try {
      datos = JSON.parse(texto);
    } catch (e) {
      // si no es json lo dejamos como texto
      datos = texto;
    }
  }

  // mostramos siempre lo que paso, bueno o malo
  mostrarRespuesta(metodo, url, respuesta.status, datos);
  return { estado: respuesta.status, datos: datos };
}

// pinta el panel con el codigo de estado y el cuerpo recibido
function mostrarRespuesta(metodo, url, estado, datos) {
  const caja = el("estado-http");
  const nombre = NOMBRES_ESTADO[estado] || "";
  caja.textContent = metodo + " " + url + "  ->  " + estado + " " + nombre;

  // el color depende de la familia del codigo
  caja.className = "estado " + (estado < 300 ? "exito" : estado < 500 ? "cliente" : "servidor");

  // mostramos el cuerpo con sangria para leerlo mejor
  el("cuerpo-http").textContent = datos === null ? "(sin cuerpo)" : (typeof datos === "string" ? datos : JSON.stringify(datos, null, 2));
}

// crea una celda de tabla con texto seguro: asignar como texto no interpreta html
function celda(texto) {
  const td = document.createElement("td");
  td.textContent = texto;
  return td;
}

// descarga los productos y rellena la tabla y el selector del formulario
async function cargarProductos() {
  const respuesta = await fetch(BASE + "/api/productos");
  const productos = await respuesta.json();

  const cuerpo = document.querySelector("#tabla-productos tbody");
  const selector = el("mov-codigo");
  cuerpo.replaceChildren();
  selector.replaceChildren();

  for (const p of productos) {
    // una fila por producto
    const fila = document.createElement("tr");
    fila.append(celda(p.codigo), celda(p.nombre), celda(p.stock), celda(p.stockMinimo));

    // etiqueta de color segun el stock
    const estado = document.createElement("td");
    const etiqueta = document.createElement("span");
    const reponer = p.stock <= p.stockMinimo;
    etiqueta.className = "etiqueta " + (reponer ? "reponer" : "ok");
    etiqueta.textContent = reponer ? "reponer" : "ok";
    estado.append(etiqueta);
    fila.append(estado);
    cuerpo.append(fila);

    // una opcion por producto en el selector
    const opcion = document.createElement("option");
    opcion.value = p.codigo;
    opcion.textContent = p.codigo + " - " + p.nombre;
    selector.append(opcion);
  }
}

// descarga el historial y rellena la tabla
async function cargarHistorial() {
  const respuesta = await fetch(BASE + "/api/movimientos?limite=8");
  const movimientos = await respuesta.json();

  const cuerpo = document.querySelector("#tabla-historial tbody");
  cuerpo.replaceChildren();

  for (const m of movimientos) {
    const fila = document.createElement("tr");
    fila.append(celda(m.id), celda(m.codigo), celda(m.tipo), celda(m.cantidad), celda(m.motivo || ""));
    cuerpo.append(fila);
  }
}

// vuelve a pedir las dos tablas
async function refrescar() {
  await cargarProductos();
  await cargarHistorial();
}

// formulario de movimiento: arma el objeto y lo envia
el("form-movimiento").addEventListener("submit", async (evento) => {
  // evitamos que el navegador recargue la pagina
  evento.preventDefault();
  const movimiento = {
    codigo: el("mov-codigo").value,
    tipo: el("mov-tipo").value,
    cantidad: Number(el("mov-cantidad").value),
    motivo: el("mov-motivo").value || null
  };
  await llamar("POST", "/api/movimientos", movimiento);
  await refrescar();
});

// formulario de producto nuevo
el("form-producto").addEventListener("submit", async (evento) => {
  evento.preventDefault();
  const producto = {
    codigo: el("prod-codigo").value,
    nombre: el("prod-nombre").value,
    stock: Number(el("prod-stock").value),
    stockMinimo: Number(el("prod-minimo").value)
  };
  await llamar("POST", "/api/productos", producto);
  await refrescar();
});

// boton de lote: se envia exactamente el texto del cuadro
el("btn-lote").addEventListener("click", async () => {
  await llamar("POST", "/api/movimientos/lote", el("lote-json").value, true);
  await refrescar();
});

// selector de archivo: lee el .json elegido y lo pone en el cuadro de texto
el("lote-archivo").addEventListener("change", async (evento) => {
  const archivo = evento.target.files[0];
  if (!archivo) return;
  // el navegador no deja leer rutas del disco: solo el archivo que el usuario elige
  el("lote-json").value = await archivo.text();
  el("lote-archivo-nombre").textContent = "archivo cargado: " + archivo.name;
  // limpiamos el selector para poder elegir el mismo archivo dos veces seguidas
  evento.target.value = "";
});

// borra los datos; el parametro indica si se recargan los de ejemplo
async function reiniciar(conEjemplo, pregunta) {
  // confirm devuelve falso si el usuario cancela
  if (!confirm(pregunta)) return;
  await llamar("POST", "/api/reiniciar?ejemplo=" + conEjemplo);
  await refrescar();
}

// boton que deja la base como al inicio
el("btn-reiniciar").addEventListener("click", () => reiniciar(true, "Se borraran todos los datos y se cargaran los productos de ejemplo. Continuar?"));

// boton que deja la base completamente vacia
el("btn-vaciar").addEventListener("click", () => reiniciar(false, "Se borraran todos los productos y movimientos. Continuar?"));

// al abrir la pagina ponemos el lote de ejemplo y cargamos las tablas
el("lote-json").value = JSON.stringify(LOTE_EJEMPLO, null, 2);
refrescar();
