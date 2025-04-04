# FoodTruck
📄 Hoja de Requerimientos – Sistema de Ventas de Comida Callejera
🧾 1. Descripción General del Sistema
El sistema de ventas de comida callejera permitirá gestionar de forma eficiente la venta de productos alimenticios desde un punto móvil (carrito, food truck o puesto fijo). El sistema controlará el inventario, gestionará pedidos, calculará ventas y generará reportes.

🧑‍💼 2. Actores del Sistema
Administrador: Administra productos, precios, usuarios, y genera reportes.

Vendedor: Registra ventas y consulta productos disponibles.

Cliente: (No registrado en el sistema) Realiza compras.

🧩 3. Módulos del Sistema
✅ 3.1. Gestión de Productos
Agregar, editar y eliminar productos (nombre, descripción, precio, categoría, imagen).

Control de stock (cantidad disponible por producto).

✅ 3.2. Gestión de Ventas
Registrar venta de productos con detalle de fecha, hora, vendedor y total.

Calcular el total automáticamente y aplicar descuentos si es necesario.

Control de métodos de pago: efectivo, tarjeta, transferencia.

✅ 3.3. Gestión de Usuarios
Registro de vendedores con roles y autenticación (usuario/contraseña).

Control de accesos según el rol (administrador vs vendedor).

✅ 3.4. Gestión de Inventario
Actualización automática del inventario tras cada venta.

Alertas de productos con bajo stock.

✅ 3.5. Reportes
Ventas por día, semana y mes.

Productos más vendidos.

Ganancias totales por periodo.

Registro de ventas por vendedor.

📦 4. Entidades Principales
Producto: Id, nombre, descripción, precio, categoría, stock, imagen.

Usuario: Id, nombre, correo, contraseña, rol.

Venta: Id, fecha, total, método de pago, vendedorId.

DetalleVenta: Id, ventaId, productoId, cantidad, subtotal.

Inventario: productoId, cantidad actual.

Reporte: fechaInicio, fechaFin, totalVentas, totalGanancias.

🔒 5. Requisitos No Funcionales
Interfaz intuitiva y adaptada a móviles (para usar desde un teléfono en la calle).

Seguridad básica (hash de contraseñas).

Registro de errores o logs.

Soporte offline (opcional).

Base de datos local o en la nube (según escalabilidad deseada).

💻 6. Tecnologías Sugeridas
Frontend: WinForms, Java Swing, Blazor, React (según entorno).

Backend: C# con Onion Architecture (ideal para práctica).

Base de Datos: SQL Server, SQLite o MySQL.
