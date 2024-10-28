const apiBaseUrl = "https://localhost:7194/api/Controlador_Producto"; 


async function obtenerProductos() {
    const response = await fetch(apiBaseUrl);
    const productos = await response.json();
    const productosList = document.getElementById("productos");
    productosList.innerHTML = productos.map(p => `<ul>${p.nombre}</ul>`).join("");
}


async function encontrarProducto() {
    const prodId = document.getElementById("prodId").value;
    const response = await fetch(`${apiBaseUrl}/${prodId}`);
    const producto = await response.json();
    document.getElementById("producto").innerText = producto ? producto.nombre : "Producto no encontrado";
}


// Función para agregar un producto a la lista visual sin recargar todo
function agregarProductoALista(producto) {
    const productosList = document.getElementById("productos");
    const nuevoElemento = document.createElement("ul");

    if (producto && producto.nombre) {
        nuevoElemento.textContent = `${producto.nombre}`;
    } else {
        console.error('El producto o su nombre no están definidos');
        nuevoElemento.textContent = 'Producto desconocido'; // O algún valor predeterminado
    }

    productosList.appendChild(nuevoElemento);
}



async function actualizarProducto() {
    const prodId = document.getElementById("prodIdUpdate").value;
    const prodName = document.getElementById("prodNameUpdate").value;
    await fetch(`${apiBaseUrl}/${prodId}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ nombre: prodName })
    });
    obtenerProductos();
}


async function eliminarProducto() {
    const prodId = document.getElementById("prodIdDelete").value;
    await fetch(`${apiBaseUrl}/${prodId}`, { method: "DELETE" });
    obtenerProductos();
}


document.addEventListener("DOMContentLoaded", obtenerProductos);
