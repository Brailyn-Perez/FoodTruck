**ESPECIFICACIÓN DE REQUERIMIENTOS DE SOFTWARE (SRS)**

---

# Sistema de Ventas de Comida Callejera

## 1. Introducción

### 1.1 Propósito
El propósito de este documento es describir los requerimientos funcionales y no funcionales del sistema de ventas de comida callejera. Este sistema busca mejorar la eficiencia en la gestión de ventas, inventario y reportes para un puesto de comida callejera.

### 1.2 Alcance
El sistema permitirá:
- Registrar productos y su inventario.
- Gestionar ventas por parte de vendedores.
- Calcular el total de ventas y generar reportes.
- Administrar usuarios con diferentes roles.

### 1.3 Definiciones, acrónimos y abreviaturas
- **SRS**: Software Requirements Specification
- **CRUD**: Create, Read, Update, Delete
- **UI**: User Interface (Interfaz de Usuario)
- **DB**: Base de Datos

---

## 2. Descripción general

### 2.1 Perspectiva del producto
El sistema es una aplicación autónoma o web/mobile que puede operar en dispositivos con conectividad limitada, enfocada a vendedores de comida en la calle.

### 2.2 Funciones del producto
- Gestión de productos (CRUD)
- Registro de ventas y métodos de pago
- Gestión de usuarios y roles
- Generación de reportes de ventas e inventario

### 2.3 Características del usuario
- **Administrador**: Acceso completo al sistema, puede gestionar usuarios, productos y ver reportes.
- **Vendedor**: Puede consultar productos y registrar ventas.

---

## 3. Requerimientos funcionales

### RF01 - Gestión de Productos
- El sistema debe permitir agregar, editar y eliminar productos.
- Cada producto debe tener: nombre, descripción, precio, categoría, imagen y stock.

### RF02 - Registro de Ventas
- El sistema debe permitir registrar ventas con fecha, hora, productos, cantidades, total y vendedor.
- Se deben aceptar métodos de pago: efectivo, tarjeta y transferencia.

### RF03 - Gestión de Inventario
- El stock debe disminuir automáticamente tras cada venta.
- Se deben generar alertas por bajo inventario.

### RF04 - Gestión de Usuarios
- El sistema debe permitir crear y gestionar usuarios con roles diferenciados.
- Los usuarios deben iniciar sesión con credenciales seguras.

### RF05 - Reportes
- El sistema debe generar reportes diarios, semanales y mensuales de ventas.
- Se debe mostrar un ranking de productos más vendidos.

---

## 4. Requerimientos no funcionales

### RNF01 - Usabilidad
- La interfaz debe ser intuitiva y fácil de usar en dispositivos móviles.

### RNF02 - Seguridad
- Las contraseñas deben estar cifradas.
- Solo usuarios autenticados pueden acceder al sistema.

### RNF03 - Rendimiento
- El sistema debe ser capaz de manejar múltiples ventas simultáneas sin degradación.

### RNF04 - Portabilidad
- El sistema debe poder ejecutarse en sistemas Android o navegadores modernos.

### RNF05 - Mantenibilidad
- El sistema debe seguir principios de arquitectura modular.

---

## 5. Modelo de datos (Resumen de entidades)
- **Producto:** Id, Nombre, Descripción, Precio, Categoría, Stock, Imagen.
- **Usuario:** Id, Nombre, Correo, Contraseña, Rol.
- **Venta:** Id, Fecha, Total, MétodoPago, VendedorId.
- **DetalleVenta:** Id, VentaId, ProductoId, Cantidad, Subtotal.
- **Reporte:** FechaInicio, FechaFin, TotalVentas, TotalGanancias.

---

## 6. Diagrama de casos de uso
*Se incluirán gráficamente los casos de uso: Gestión de productos, Registrar ventas, Ver reportes, Iniciar sesión, etc.*

---

## 7. Requisitos del sistema
- Base de datos SQL (SQLite o MySQL).
- Backend en C# con arquitectura limpia u Onion Architecture.
- Interfaz en WinForms, Web o Mobile.

---

## 8. Aprobaciones
*Este documento debe ser aprobado por el analista de sistemas y los stakeholders del proyecto.*

